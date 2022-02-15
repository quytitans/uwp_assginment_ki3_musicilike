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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MainStudyApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddSongPage : Page
    {
        public bool checkAll = true;
        public AddSongPage()
        {
            this.InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
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
        }
    }
}
