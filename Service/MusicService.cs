using MainStudyApp.Config;
using MainStudyApp.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MainStudyApp.Service
{
    class MusicService
    {    
        //add new public song
        public static async Task<bool> CreatePublicSongAsync(Song song)
        {
            var jsonString = JsonConvert.SerializeObject(song);

            HttpClient httpClient = new HttpClient();
            var apiUrl = APIConfig.domain + APIConfig.URL_AddPublicSong;
            HttpContent contentToSend = new StringContent(jsonString, Encoding.UTF8, "applicaion/json");
            var result = await httpClient.PostAsync(apiUrl, contentToSend);
            if (result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Create new song";
                dialog.Content = "Create new song success";
                dialog.CloseButtonText = "Close";
                await dialog.ShowAsync();
                return true;
            }
            else
            {
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Create new song";
                dialog.Content = "Action faile please try again !!!";
                dialog.CloseButtonText = "Close";
                await dialog.ShowAsync();
                return false;
            }
        }
        //get lastest songs
        public async Task<List<Song>> GetLastestSongsAsync()
        {
            var listLastestSongs = new List<Song>();
            var apiUrl = APIConfig.domain + APIConfig.URL_LastestSongs;
            using (HttpClient httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(apiUrl);
                if(result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    listLastestSongs = JsonConvert.DeserializeObject<List<Song>>(content);
                }
                else
                {
                    Debug.WriteLine("something went wrong");
                }                
            }
            return listLastestSongs;
        }
        //add my song
        public static async Task<bool> CreateMySongAsync(Song song)
        {
            var apiUrl = APIConfig.domain + APIConfig.URL_AddMySong;
            Credential credential = await AccountService.LoadToken();
            var jsonString = JsonConvert.SerializeObject(song);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", credential.access_token);
            HttpContent contentToSend = new StringContent(jsonString, Encoding.UTF8, "applicaion/json");
            var result = await httpClient.PostAsync(apiUrl, contentToSend);
            if (result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //get my song
        public async Task<List<Song>> GetListSongMineAsync()
        {
            var apiUrl = APIConfig.domain + APIConfig.URL_MySongs;
            List<Song> listSong = new List<Song>();
            Credential credential = await AccountService.LoadToken();
            if (credential == null)
            {
                return listSong;
            }
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", credential.access_token);
                var result = await httpClient.GetAsync(apiUrl);
                var content = await result.Content.ReadAsStringAsync();
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                   listSong = JsonConvert.DeserializeObject<List<Song>>(content);
                }
                else
                {
                   Debug.WriteLine("Error 500");
                }
            }
            return listSong;
        }
    }
}