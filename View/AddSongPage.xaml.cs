using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MainStudyApp.Entity;
using MainStudyApp.Service;
using MainStudyApp.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MainStudyApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddSongPage : Windows.UI.Xaml.Controls.Page
    {
        int typeUpload = 0;
        //config cloudiary        
        private CloudinaryDotNet.Account accountCloudinary;
        private Cloudinary cloudinary;
        Frame rootFrame = Window.Current.Content as Frame;
        public bool checkAll = true;
        public AddSongPage()
        {
            this.InitializeComponent();
            this.Loaded += AddSongPage_Loaded1;
        }

        private void AddSongPage_Loaded1(object sender, RoutedEventArgs e)
        {
            //accountCloudinary = new CloudinaryDotNet.Account(
            //"dark-faith",
            //"953928119328554",
            //"V2Jg1mDPkFzDX3dSX8fYPn_zvXQ"
            //);
            //cloudinary = new Cloudinary(accountCloudinary);
            //cloudinary.Api.Secure = true;
        }

        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            checkAll = true;
            if (ValidateInput.IsStringInvalid(inputSongName.Text, 2))
            {
                msgSongName.Text = "Song's name must be atlest 3 letters";
                checkAll = false;
            }

            if (ValidateInput.IsStringInvalid(inputSingerName.Text, 2))
            {
                msgSingerName.Text = "Singer's name must be atlest 3 letters";
                checkAll = false;
            }

            if (ValidateInput.IsStringInvalid(inputAuthorName.Text, 2))
            {
                msgAuthorName.Text = "Author's name must be atlest 3 letters";
                checkAll = false;
            }

            if (ValidateInput.IsStringInvalid(inputThumnail.Text, 2))
            {
                msgThumnail.Text = "Link thumbnail must be atlest 3 letters";
                checkAll = false;
            }

            if (ValidateInput.IsStringInvalid(inputLink.Text, 2))
            {
                msgLink.Text = "Song's link must be atlest 3 letters";
                checkAll = false;
            }

            if (checkAll)
            {
                var songCreate = new Song()
                {
                    name = inputSongName.Text,
                    description = "very nice",
                    singer = inputSingerName.Text,
                    author = inputAuthorName.Text,
                    thumbnail = inputThumnail.Text,
                    link = inputLink.Text,
                };
                bool result = false;
                if (typeUpload == 0)
                {
                    result = await MusicService.CreatePublicSongAsync(songCreate);
                }else if(typeUpload == 1)
                {
                    result = await MusicService.CreateMySongAsync(songCreate);
                }
                
                ContentDialog contentDialog = new ContentDialog();                
                if (result)
                {
                    contentDialog.Title = "Upload new song";
                    contentDialog.Content = "Upload success";
                }
                else
                {
                    contentDialog.Title = "Upload new song";
                    contentDialog.Content = "Upload fail";
                }
                contentDialog.CloseButtonText = "Close";
                await contentDialog.ShowAsync();
                rootFrame.Navigate(typeof(View.HomePage));
            }
        }

        private async void Button_CreateThumbnail(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                BitmapImage bitmapImage = new BitmapImage();
                IRandomAccessStream fileStream = await file.OpenReadAsync();
                await bitmapImage.SetSourceAsync(fileStream);
                //imgThumbnail.Source = bitmapImage;
                RawUploadParams imageUploadParams = new RawUploadParams()
                {
                    File = new FileDescription(file.Name, await file.OpenStreamForReadAsync())
                };
                RawUploadResult result = await cloudinary.UploadAsync(imageUploadParams);
                //publicIDCloudinary = result.PublicId;
                inputThumnail.Text = result.Url.ToString();                
            }
            else
            {
                Debug.WriteLine("Action faile");
            }
        }

        private void isUploadMySingChecked_Checked(object sender, RoutedEventArgs e)
        {
            typeUpload = 1;
        }

        private void isUploadMySingChecked_Unchecked(object sender, RoutedEventArgs e)
        {
            typeUpload = 0;
        }
    }
}
