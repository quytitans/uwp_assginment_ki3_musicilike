using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainStudyApp.Config
{
    class APIConfig
    {
        public static string domain = "https://music-i-like.herokuapp.com";
        public static string URL_Register = "/api/v1/accounts";
        public static string URL_Login = "/api/v1/accounts/authentication";
        public static string URL_AccountInformation = "/api/v1/accounts";
        public static string URL_LastestSongs = "/api/v1/songs";
        public static string URL_MySongs = "/api/v1/songs/mine";
        public static string URL_AddPublicSong = "/api/v1/songs";
        public static string URL_AddMySong = "/api/v1/songs/mine";
    }
}
