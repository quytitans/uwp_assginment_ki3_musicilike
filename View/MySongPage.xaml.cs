using MainStudyApp.Entity;
using MainStudyApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
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
    public sealed partial class MySongPage : Page
    {
        int indexSong;
        MediaPlaybackList _mediaPlaybackList;
        MusicService musicService = new MusicService();
        public List<Song> listSongs { get; set; }
        public MySongPage()
        {
            this.InitializeComponent();
            this.Loaded += ListSongAllPage_Loaded;
        }

        private async void ListSongAllPage_Loaded(object sender, RoutedEventArgs e)
        {
            List<Song> listSongCheck = await musicService.GetListSongMineAsync();

            _mediaPlaybackList = new MediaPlaybackList();
            for (int i = 0; i < listSongCheck.Count; i++)
            {
                try
                {
                    var mediaPlaybackItem = new MediaPlaybackItem(MediaSource.CreateFromUri(new Uri(listSongCheck[i].link)));
                    _mediaPlaybackList.Items.Add(mediaPlaybackItem);
                }
                catch (Exception ex)
                {
                    var mediaPlaybackItemNull = new MediaPlaybackItem(MediaSource.CreateFromUri(new Uri("about:blank")));
                    _mediaPlaybackList.Items.Add(mediaPlaybackItemNull);
                }
            }
            ObservableCollection<Song> observableSongs = new ObservableCollection<Song>(listSongCheck);
            MyListSong.ItemsSource = observableSongs;

            _mediaPlaybackList.CurrentItemChanged += MediaPlaybackList_CurrentItemChanged;

            var _mediaPlayer = new MediaPlayer();
            _mediaPlayer.Source = _mediaPlaybackList;
            MyMediaPlayer.SetMediaPlayer(_mediaPlayer);
        }

        private async void MediaPlaybackList_CurrentItemChanged(MediaPlaybackList sender, CurrentMediaPlaybackItemChangedEventArgs args)
        {
            indexSong = (int)sender.CurrentItemIndex;
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => {
                MyListSong.SelectedIndex = indexSong;
            });
        }

        private void MyListSong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            indexSong = MyListSong.SelectedIndex;
            if (indexSong != -1)
            {
                _mediaPlaybackList.MoveTo(Convert.ToUInt32(indexSong));
            }
        }
    }
}
