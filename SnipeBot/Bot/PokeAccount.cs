

using SnipeBot.UserLogger;
using SnipeBot.Utils;
using POGOProtos.Data;
using POGOProtos.Enums;
using POGOProtos.Inventory;
using POGOProtos.Inventory.Item;
using POGOProtos.Map.Fort;
using POGOProtos.Map.Pokemon;
using POGOProtos.Networking.Responses;
using PokemonGo.RocketAPI;
using PokemonGo.RocketAPI.Enums;
using PokemonGo.RocketAPI.Exceptions;
using PokemonGo.RocketAPI.Extensions;

using PokemonGo.RocketAPI.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnipeBot.Bot
{
    public class PokeAccount
    {
        public readonly Client _client;
        public readonly ISettings _clientSettings;
        public readonly Inventory _inventory;
        public readonly Navigation _navigation;

        public Dictionary<Navigation.Location, PokemonId> PokemonToSnipe = new Dictionary<Navigation.Location, PokemonId>();

        public AsyncManualResetEvent SnipeEnabled = new AsyncManualResetEvent();

        public bool running = false;

        public Random rand = new Random();

        public bool Logged = false;

        public static float CalculatePokemonPerfection(PokemonData poke)
        {
            return ((float)(poke.IndividualAttack * 2 + poke.IndividualDefense + poke.IndividualStamina) / (4.0f * 15.0f)) * 100.0f;
        }

        public PokeAccount(ISettings clientSettings)
        {

            _clientSettings = clientSettings;
            _client = new Client(_clientSettings);
            _inventory = new Inventory(_client);
            _navigation = new Navigation(_client);
            //_client.Login.GoogleDeviceCodeEvent += Login_GoogleDeviceCodeEvent;
        }


        public async Task Execute()
        {
          
            running = true;
            //_client.Login.GoogleDeviceCodeEvent += Login_GoogleDeviceCodeEvent;
            while (running)
            {
                try
                {
                    
                    await PostLoginExecute();
                }
                catch (Exception ex)
                {
                    Logger.Write($"Execute Exception: {ex}", LogLevel.Info, ConsoleColor.Red);
                }
                Logger.Write($"Looping Execute Again", LogLevel.Info);
                await T.Delay(rand.Next(8000, 15000));
            }
        }

        private void Login_GoogleDeviceCodeEvent(string code, string uri)
        {

            Logger.Write($"Your Google Device Code is {code} enter it at {uri}", LogLevel.Info, ConsoleColor.White);

            Logger.Write("Once entered, please wait for the bot to start...", LogLevel.Info, ConsoleColor.White);


        }
        public async Task PostLoginExecute()
        {
            while (running)
            {
                Logger.Write($"Starting Execute on login server: {_clientSettings.AuthType}", LogLevel.Info, ConsoleColor.Magenta);
                if (!await Login())
                {
                    Logger.Write("Login failed...!", LogLevel.Error, ConsoleColor.Red);
                    break;
                }

                
                try
                {
                    // wait for sniping to be enabled
                    await SnipeEnabled.WaitAsync();

                    // snipe pokemon

                    Logger.Write($"Starting sniper on {PokemonToSnipe.Count} pokemon coords", LogLevel.Info, ConsoleColor.Blue);

                    foreach (var pair in PokemonToSnipe)
                    {
                        retry:
                        try
                        {
                            Logger.Write($"Updating player location to pokemon {pair.Value} at {pair.Key.Latitude}, {pair.Key.Longitude}", LogLevel.Info, ConsoleColor.Blue);

                            await _client.Player.UpdatePlayerLocation(pair.Key.Latitude, pair.Key.Longitude, UserSettings.Altitude);

                            await SnipePokemon(pair.Value);
                        }
                        catch (Exception ex)
                        {
                            await T.Delay(4000);
                            goto retry;
                        }
                    }



                    // clear
                    PokemonToSnipe.Clear();

                    // reset handler
                    SnipeEnabled.Reset();
                }
                catch (Exception ex)
                { 
                    Logger.Write($"Post Execute Exception: {ex}", LogLevel.Info, ConsoleColor.Red);
                }
                await Task.Delay(1000);
            }
            Logger.Write($"Bot being stopped, perhaps login failed?", LogLevel.Info, ConsoleColor.Red);

        }

        public async Task<bool> Login()
        {
            try
            {
                if (_clientSettings.AuthType == AuthType.Ptc)
                    await _client.Login.DoPtcLogin(UserSettings.Username, UserSettings.Password);
                else if (_clientSettings.AuthType == AuthType.Google)
                {
                    await _client.Login.DoGoogleLogin(UserSettings.Username, UserSettings.Password);
                }
                Logger.Write("Successful Login", LogLevel.Info, ConsoleColor.Magenta);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Write($"Login Exception: {ex}", LogLevel.Info, ConsoleColor.Red);
            }
            return false;
        }


        private async Task SnipePokemon(PokemonId pid)
        {
            // update location before this to the pokemon


            var mapObjects = await _client.Map.GetMapObjects();

            var catchPokemons = mapObjects.MapCells.SelectMany(i => i.CatchablePokemons).Where(i => i.PokemonId == pid).OrderBy(i => LocationUtils.CalculateDistanceInMeters(new Navigation.Location(_client.CurrentLatitude, _client.CurrentLongitude), new Navigation.Location(i.Latitude, i.Longitude)));

            if (catchPokemons.ToList().Count == 0)
            {
                Logger.Write($"Could not find a {pid} at the location given! Teleporting home.");
                await _client.Player.UpdatePlayerLocation(_client.Settings.DefaultLatitude, _client.Settings.DefaultLongitude, _client.Settings.DefaultAltitude);
                return;
            }


            var pokemon = catchPokemons.First();
            // catch
            try
            {
                // we'll teleport if we're on the walk? I don't think that'd be wise
                var dist = LocationUtils.CalculateDistanceInMeters(new Navigation.Location(_client.CurrentLatitude, _client.CurrentLongitude), new Navigation.Location(pokemon.Latitude, pokemon.Longitude));

                var encounter = await _client.Encounter.EncounterPokemon(pokemon.EncounterId, pokemon.SpawnPointId);

                await _client.Player.UpdatePlayerLocation(_client.Settings.DefaultLatitude, _client.Settings.DefaultLongitude, _client.Settings.DefaultAltitude);

                if (encounter.Status == EncounterResponse.Types.Status.EncounterSuccess)
                {
                    Logger.Write("Encountered pokemon successfully, teleporting back to original coordinates", LogLevel.Info, ConsoleColor.Yellow);
                    await CatchEncounter(encounter, pokemon);
                }
                else
                {
                    Logger.Write($"Encounter Error: {encounter?.Status}", LogLevel.Error, ConsoleColor.Red);

                }

            }
            catch (Exception ex)
            {
                Logger.Write($"Exception Catch MapPokemon: {ex}", LogLevel.Error, ConsoleColor.Red);
            }
            
        }


        private async Task CatchEncounter(EncounterResponse encounter, MapPokemon pokemon)
        {

            CatchPokemonResponse caughtPokemonResponse;
            do
            {
                try
                {
                    PokemonData pokeData = encounter?.WildPokemon?.PokemonData;

                    if (encounter?.CaptureProbability != null && encounter?.CaptureProbability.CaptureProbability_.First() < (UserSettings.BerryProbability / 100))
                    {
                        if (pokeData != null)
                        {
                            await UseBerry(pokemon.EncounterId, pokemon.SpawnPointId);
                        }
                    }

                    var pokeball = await GetBestBall(encounter?.WildPokemon);

                    if (pokeball == ItemId.ItemUnknown)
                    {
                        Logger.Write("No Pokeballs to use! STOPPING BOT!", LogLevel.Error, ConsoleColor.Red);
                        running = false;
                        return;
                    }
                    caughtPokemonResponse = await _client.Encounter.CatchPokemon(pokemon.EncounterId, pokemon.SpawnPointId, pokeball);

                    Logger.Write(caughtPokemonResponse.Status == CatchPokemonResponse.Types.CatchStatus.CatchSuccess ? $"We caught a {pokemon.PokemonId} with CP {encounter?.WildPokemon?.PokemonData?.Cp} ({CalculatePokemonPerfection(encounter?.WildPokemon?.PokemonData).ToString("0.00")}% perfection) using a {pokeball}" : $"{pokemon.PokemonId} with CP {encounter?.WildPokemon?.PokemonData?.Cp} got away while using a {pokeball}..", LogLevel.Info, ConsoleColor.Green);

                    if (caughtPokemonResponse.Status == CatchPokemonResponse.Types.CatchStatus.CatchSuccess)
                    {
                        pokeData = encounter?.WildPokemon?.PokemonData;
                    }

                    await T.Delay(rand.Next(1500, 3000));
                }
                catch (Exception ex)
                {
                    Logger.Write($"Exception in Encounter: {ex}", LogLevel.Error, ConsoleColor.Red);
                    break;
                }
            }
            while (caughtPokemonResponse.Status == CatchPokemonResponse.Types.CatchStatus.CatchMissed);
        }

        public async Task UseBerry(ulong encounterId, string spawnPointId)
        {
            if (!UserSettings.UseBerries)
                return;

            var inventoryBalls = await _inventory.GetItems();
            var berries = inventoryBalls.Where(p => (ItemId)p.ItemId == ItemId.ItemRazzBerry);
            var berry = berries.FirstOrDefault();

            if (berry == null)
                return;

            var useRaspberry = await _client.Encounter.UseCaptureItem(encounterId, ItemId.ItemRazzBerry, spawnPointId);
            Logger.Write($"Use Rasperry. Remaining: {berry.Count}", LogLevel.Info);
            await T.Delay(rand.Next(4000, 8000));
        }

        private async Task<ItemId> GetBestBall(WildPokemon pokemon)
        {
            var pokemonCp = pokemon?.PokemonData?.Cp;

            var items = await _inventory.GetItems();
            var balls = items.Where(i => (i.ItemId == ItemId.ItemPokeBall
                                      || i.ItemId == ItemId.ItemGreatBall
                                      || i.ItemId == ItemId.ItemUltraBall
                                      || i.ItemId == ItemId.ItemMasterBall) && i.Count > 0).GroupBy(i => (i.ItemId)).ToList();
            if (balls.Count == 0) return ItemId.ItemUnknown;

            var pokeBalls = balls.Any(g => g.Key == ItemId.ItemPokeBall);
            var greatBalls = balls.Any(g => g.Key == ItemId.ItemGreatBall);
            var ultraBalls = balls.Any(g => g.Key == ItemId.ItemUltraBall);
            var masterBalls = balls.Any(g => g.Key == ItemId.ItemMasterBall);

            if (masterBalls && pokemonCp >= 2000)
                return ItemId.ItemMasterBall;
            else if (ultraBalls && pokemonCp >= 2000)
                return ItemId.ItemUltraBall;
            else if (greatBalls && pokemonCp >= 2000)
                return ItemId.ItemGreatBall;

            if (ultraBalls && pokemonCp >= 1000)
                return ItemId.ItemUltraBall;
            else if (greatBalls && pokemonCp >= 1000)
                return ItemId.ItemGreatBall;

            if (greatBalls && pokemonCp >= 500)
                return ItemId.ItemGreatBall;

            return balls.OrderBy(g => g.Key).First().Key;
        }
    }
}
