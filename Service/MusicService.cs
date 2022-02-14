using MainStudyApp.Config;
using MainStudyApp.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MainStudyApp.Service
{
    class MusicService
    {
        AccountService accountService = new AccountService();
        //add new song

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
        //get my song
        //add my song
    }
}
