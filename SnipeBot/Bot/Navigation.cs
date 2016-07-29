using SnipeBot.UserLogger;
using POGOProtos.Networking.Responses;
using PokemonGo.RocketAPI;
using System;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;

namespace SnipeBot.Utils
{
    public class Navigation
    {

        private static readonly double speedDownTo = 10 / 3.6;
        private readonly Client _client;

        private Random rand = new Random();
        public Navigation(Client client)
        {
            _client = client;
        }

        public class Location
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }

            public Location(double latitude, double longitude)
            {
                Latitude = latitude;
                Longitude = longitude;
            }
        }
    }
}