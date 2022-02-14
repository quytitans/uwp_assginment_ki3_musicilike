using MainStudyApp.Entity;
using MainStudyApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
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
    public sealed partial class LastestSongsPage : Page
    {
        MusicService musicService = new MusicService();
        public List<Song> listSongs { get; set; }
        public LastestSongsPage()
        {
            this.InitializeComponent();
            this.Loaded += ListSongAllPage_Loaded;
        }

        private async void ListSongAllPage_Loaded(object sender, RoutedEventArgs e)
        {
            listSongs = new List<Song>();
            listSongs = await musicService.GetLastestSongsAsync();
            MyListSong.ItemsSource = listSongs;
        }

        private void MyListSong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Song currentSong = MyListSong.SelectedItem as Song;
            MyMediaPlayer.MediaPlayer.Source = MediaSource.CreateFromUri(new Uri(currentSong.link));
            MyMediaPlayer.MediaPlayer.Play();
        }
    }
}
