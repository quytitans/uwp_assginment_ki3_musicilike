using MainStudyApp.Util;
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
using MainStudyApp.Entity;
using MainStudyApp.Service;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MainStudyApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void SubmitClick (object sender, RoutedEventArgs e)
        {
            var checkAll = true;

            if (ValidateInput.IsStringInvalid(inputPassword.Password, 4))
            {
                msgPassword.Text = "Password must be atlest 5 letters";
                checkAll = false;
            }
            else
            {
                msgPassword.Text = "";
            }

            if (ValidateInput.IsEmail(inputEmail.Text))
            {
                msgEmail.Text = "";
            }
            else
            {
                msgEmail.Text = "Email is invalid";
                checkAll = false;
            }

            if (checkAll)
            {
                var newLogin = new LoginInformation
                {
                    email = inputEmail.Text,
                    password = inputPassword.Password
                };
                AccountService.loginAsync(newLogin);
            }
        }

        private void btnResetClick(object sender, RoutedEventArgs e)
        {
            inputEmail.Text = "";
            inputPassword.Password = "";
            msgEmail.Text = "";
            msgPassword.Text = "";
        }
    }
}
