using MainStudyApp.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MainStudyApp.Service
{
    class AccountService
    {
        public static async void saveAccount(Account account)
        {
            string apiUrl = "https://music-i-like.herokuapp.com/api/v1/accounts";
            var jsonString = JsonConvert.SerializeObject(account);
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpContent contentToSend = new StringContent(jsonString, Encoding.UTF8, "application/json");
                //httpClient.BaseAddress = new Uri(apiUrl);
                var result = await httpClient.PostAsync(apiUrl, contentToSend);
                if (result.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    Account returnAccount = JsonConvert.DeserializeObject<Account>(content);
                    Debug.WriteLine("Done !!!");
                    Debug.WriteLine(returnAccount.id);

                    ContentDialog dialog = new ContentDialog();
                    dialog.Title = "Create new account";
                    dialog.Content = "Create account success";
                    dialog.CloseButtonText = "Close";          
                    await dialog.ShowAsync();

                }
                else
                {
                    ContentDialog dialog = new ContentDialog();
                    dialog.Title = "Create new account";
                    dialog.Content = "Create account faile please try again";
                    dialog.CloseButtonText = "Close";
                    await dialog.ShowAsync();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            };
        }
    }
}
