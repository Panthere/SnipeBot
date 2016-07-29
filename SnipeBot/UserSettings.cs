using PokemonGo.RocketAPI;
using PokemonGo.RocketAPI.Enums;

namespace SnipeBot
{
    public static class UserSettings
    {
        public static int Altitude;
        public static double StartLat;
        public static double StartLng;

        public static int WalkingSpeed;

        public static AuthType Auth = AuthType.Ptc;

        public static string Username;
        public static string Password;

        public static string GoogleRefreshToken;

        public static bool UseBerries;
        public static int BerryProbability;

    }

    public class Settings : ISettings
    {
        public double WalkingSpeedInKilometerPerHour => UserSettings.WalkingSpeed;


        public string GoogleRefreshToken
        {
            get { return UserSettings.GoogleRefreshToken; }
            set
            {
                UserSettings.GoogleRefreshToken = value;
            }
        }

        AuthType ISettings.AuthType
        {
            get
            {
                return UserSettings.Auth;
            }

            set
            {
                UserSettings.Auth = value;
            }
        }

        double ISettings.DefaultLatitude
        {
            get
            {
                return UserSettings.StartLat;
            }

            set
            {
                UserSettings.StartLat = value;
            }
        }

        double ISettings.DefaultLongitude
        {
            get
            {
                return UserSettings.StartLng;
            }

            set
            {
                UserSettings.StartLng = value;
            }
        }

        double ISettings.DefaultAltitude
        {
            get
            {
                return UserSettings.Altitude;
            }

            set
            {
                UserSettings.Altitude = (int)value;
            }
        }

        string ISettings.PtcPassword
        {
            get
            {
                return UserSettings.Password;
            }

            set
            {
                UserSettings.Password = value;
            }
        }

        string ISettings.PtcUsername
        {
            get
            {
                return UserSettings.Username;
            }

            set
            {
                UserSettings.Username = value;
            }
        }

        public string GoogleUsername
        {
            get
            {
                return UserSettings.Username;
            }

            set
            {
                UserSettings.Username = value;
            }
        }

        public string GooglePassword
        {
            get
            {
                return UserSettings.Password;
            }

            set
            {
                UserSettings.Password = value;
            }
        }
    }

}
