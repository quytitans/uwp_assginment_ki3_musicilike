using MainStudyApp.Entity;
using MainStudyApp.Service;
using MainStudyApp.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class RegisterPage : Page
    {
        Frame rootFrame = Window.Current.Content as Frame;
        public int genderSelected = -1;
        public string birthdaySelected = null;
        public bool checkAll = true;
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        private void SubmitBtnCLick(object sender, RoutedEventArgs e)
        {
            checkAll = true;
            if(ValidateInput.IsStringInvalid(firstName.Text, 2))
            {
                msgFirstName.Text = "First Name must be atlest 3 letters";
                checkAll = false;
            }
            else
            {
                msgFirstName.Text = "";
            }

            if (ValidateInput.IsStringInvalid(lastName.Text, 2))
            {
                msgLastName.Text = "Last Name must be atlest 3 letters";
                checkAll = false;
            }
            else
            {
                msgLastName.Text = "";
            }

            if (ValidateInput.IsStringInvalid(password.Password, 4))
            {
               msgPassword.Text = "Password must be atlest 5 letters";
                checkAll = false;
            }
            else
            {
                msgPassword.Text = "";
            }

            if (ValidateInput.IsStringInvalid(confirmPassword.Password, 0))
            {
                msgConfirmPassword.Text = "Confirm Password is not empty";
                checkAll = false;
            }
            else
            {
                if(confirmPassword.Password != password.Password)
                {
                    msgConfirmPassword.Text = "Confirm must be the same with password";
                    checkAll = false;
                }
                else
                {
                    msgConfirmPassword.Text = "";
                }
            }

            if (ValidateInput.IsStringInvalid(address.Text, 0))
            {
                msgAddress.Text = "Address cant be empty";
                checkAll = false;
            }
            else
            {
                msgAddress.Text = "";
            }

            if (ValidateInput.IsPhoneNumber(phone.Text))
            {
                msgPhone.Text = "";
            }
            else
            {
                msgPhone.Text = "Phone number is invalid";
                checkAll = false;                
            }

            if (ValidateInput.IsStringInvalid(avatar.Text, 0))
            {
                msgAvatar.Text = "Avatar cant be empty";
                checkAll = false;
            }
            else
            {
                msgAvatar.Text = "";
            }

            if (ValidateInput.IsEmail(email.Text))
            {
               msgEmail.Text = "";
            }
            else
            {                
                msgEmail.Text = "Email is invalid";
                checkAll = false;
            }

            if(genderSelected == -1)
            {
                msgGender.Text = "Gender cant be empty";
                checkAll = false;
            }
            else
            {
                msgGender.Text = "";
            }

            if(birthdaySelected == null)
            {
                msgBirthDay.Text = "BirthDay cant be empty";
                checkAll = false;
            }
            else
            {
               msgBirthDay.Text = "";
            }
                        
            if (checkAll)
            {
                Account newAccount = new Account()
                {
                    firstName = firstName.Text,
                    lastName = lastName.Text,
                    password = password.Password,
                    address = address.Text,
                    phone = phone.Text,
                    avatar = avatar.Text,
                    gender = genderSelected,
                    email = email.Text,
                    birthday = birthdaySelected,
                    introduction = introduction.Text
                };
                string stringTest = JsonConvert.SerializeObject(newAccount);
                Debug.WriteLine(stringTest);
                AccountService.saveAccount(newAccount);
                rootFrame.Navigate(typeof(View.NewLoginPage));
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ResetForm();
        }

        private void RadioButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            RadioButton radioSelected = sender as RadioButton;
            switch (radioSelected.Tag)
            {
                case "male":
                    genderSelected = 1;
                    break;
                case "female":
                    genderSelected = 0;
                    break;
            }
        }

        private void CalendarDatePicker_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            birthdaySelected = sender.Date.ToString();
            string[] Split = birthdaySelected.Split("/");
            string month = Split[0];
            string day = Split[1];
            string[] Split2 = Split[2].Split(" ");
            string year = Split2[0];
            birthdaySelected = $"{year}-{month}-{day}";                   
        }

        private void ResetForm()
        {
            firstName.Text = "";
            lastName.Text = "";
            password.Password = "";
            confirmPassword.Password = "";
            address.Text = "";
            phone.Text = "";
            avatar.Text = "";
            email.Text = "";
            introduction.Text = "";
           
            msgFirstName.Text = "";
            msgLastName.Text = "";
            msgPassword.Text = "";
            msgConfirmPassword.Text = "";
            msgAddress.Text = "";
            msgPhone.Text = "";
            msgAvatar.Text = "";
            msgEmail.Text = "";
            msgGender.Text = "";
            msgBirthDay.Text = "";
        }
    }
}
