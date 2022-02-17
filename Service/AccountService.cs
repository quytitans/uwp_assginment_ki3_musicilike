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
using Windows.Storage;

namespace MainStudyApp.Service
{
    class AccountService
    {
        public static string tokenUserFile = "LoginInformation.txt";
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

        public async Task<Credential> loginAsync(LoginInformation loginInformation) {
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
                    Debug.WriteLine(content);
                    SaveToken(content);            
                    return returnCre;
                }
                 else {                    
                    return null;
                 }  
            }
        }

        public static async Task LogoutAsync()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile manifestFile = await storageFolder.GetFileAsync(tokenUserFile);
            await manifestFile.DeleteAsync();
        }

        //save token
        private async void SaveToken(string content)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.CreateFileAsync(tokenUserFile, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, content);
        }
        //load token
        public static async Task<Credential> LoadToken()
        {
            try
            {
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile sampleFile = await storageFolder.GetFileAsync(tokenUserFile);
                string JsonReaderResuilt = await FileIO.ReadTextAsync(sampleFile);
                Credential credential = JsonConvert.DeserializeObject<Credential>(JsonReaderResuilt);
                return credential;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //get account infomation
        public async Task<Account> GetAccountInformation(string token)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var apiUrl = APIConfig.domain + APIConfig.URL_AccountInformation;
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                var result = await httpClient.GetAsync(apiUrl);
                
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    Account account = JsonConvert.DeserializeObject<Account>(content);
                    App.accountUser = account;
                    return account;
                }
                else
                {
                    // bad case
                    return null;
                }
            }
        }
        public async Task<Account> GetLoggedAccount()
        {
            Account account;
            Credential credential = await LoadToken();
            if (credential == null)
            {
                return null;
            }
            account = await GetAccountInformation(credential.access_token);
            return account;
        }
    }
}
