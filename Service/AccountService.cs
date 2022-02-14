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
using MainStudyApp.Config;

namespace MainStudyApp.Service
{
    class AccountService
    {
        public static async void saveAccount(Account account)
        {            
            var apiUrl = APIConfig.domain + APIConfig.URL_Register;
            var jsonString = JsonConvert.SerializeObject(account);
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpContent contentToSend = new StringContent(jsonString, Encoding.UTF8, "application/json");                
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

        public static async Task<Credential> loginAsync(LoginInformation loginInformation) {
            var apiUrl = APIConfig.domain + APIConfig.URL_Login;
            var jsonString = JsonConvert.SerializeObject(loginInformation);
            using (HttpClient httpClient = new HttpClient())
            {
                HttpContent contentToSend = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync(apiUrl, contentToSend);
                if(result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                var content = await result.Content.ReadAsStringAsync();
                Credential returnCre = JsonConvert.DeserializeObject<Credential>(content);
               
                Debug.WriteLine("Done !!!");
                    ContentDialog dialog = new ContentDialog();
                    dialog.Title = "Login";
                    dialog.Content = "Login success !!!";
                    dialog.CloseButtonText = "Close";
                    await dialog.ShowAsync();
                    return returnCre;
                }
                 else {
                    ContentDialog dialog = new ContentDialog();
                    dialog.Title = "Login";
                    dialog.Content = "Login faile please try again";
                    dialog.CloseButtonText = "Close";
                    await dialog.ShowAsync();
                    return null;
                 }  
            }
        }
    }
}
