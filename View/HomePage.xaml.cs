using MainStudyApp.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MainStudyApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        AccountService accountService = new AccountService();
        Frame rootFrame = Window.Current.Content as Frame;
        public HomePage()
        {
            this.InitializeComponent();
            contentFrame.Navigate(typeof(View.WelcomePage));
        }        

        private void btnLastestSongsCLick(object sender, TappedRoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(View.LastestSongsPage));
        }

        private void btnAddSongClick(object sender, TappedRoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(View.AddSongPage));
        }

        private void LogoutBtn_click(object sender, TappedRoutedEventArgs e)
        {
            AccountService.LogoutAsync();
            rootFrame.Navigate(typeof(View.NewLoginPage));
        }
    }
}
