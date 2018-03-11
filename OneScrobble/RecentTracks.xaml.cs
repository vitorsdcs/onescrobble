using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using OneScrobble.Resources;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using OneScrobble.LastFm;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Xna.Framework.Media;

namespace OneScrobble
{
    public partial class RecentTracks : PhoneApplicationPage
    {
        private UserGetRecentTracks rt;

        // Constructor
        public RecentTracks()
        {
            InitializeComponent();

            this.rt = new UserGetRecentTracks(10, rtCallback);
        }

        public void rtCallback()
        {
            new TrackScrobble(MediaPlayer.Queue.ActiveSong.Artist.ToString(),
                              MediaPlayer.Queue.ActiveSong.Name,
                              (Int32)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                              MediaPlayer.Queue.ActiveSong.Album.ToString(),
                              MediaPlayer.Queue.ActiveSong.TrackNumber,
                              (Int32)MediaPlayer.Queue.ActiveSong.Duration.TotalSeconds);

            SystemTray.ProgressIndicator = new ProgressIndicator();
            SystemTray.ProgressIndicator.IsIndeterminate = true;
            SystemTray.ProgressIndicator.IsVisible = true;
            SystemTray.ProgressIndicator.Text = "Loading recent tracks...";
            renderTracks();
        }

        public async Task renderTracks()
        {
            JArray tracks = (JArray)this.rt.recentTracks["recenttracks"]["track"];

            JObject track;
            JToken jToken;

            int imgMargin = 10;
            int tb1Margin = 6;
            int tb2Margin = 35;
            int tb3Margin = 64;

            for (int i = 0; i < tracks.Count(); i++)
            {
                track = (JObject)tracks[i];
                Track t = new Track(
                    (string)track["artist"]["#text"],
                    (string)track["name"],
                    (string)track["album"]["#text"],
                    (string)track["url"],
                    (string)track["image"][2]["#text"],
                    (string)track["date"]["#text"]
                );

                //<Image HorizontalAlignment="Left" Height="80" Margin="10,10,0,0" VerticalAlignment="Top" Width="80" Source="http://userserve-ak.last.fm/serve/126/100446599.jpg"/>
                //<Image HorizontalAlignment="Left" Height="80" Margin="10,118,0,0" VerticalAlignment="Top" Width="80" Source="http://userserve-ak.last.fm/serve/126/100446599.jpg"/>
                Image img = new Image();
                img.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                img.Height = 80;
                img.Width = 80;
                img.Margin = new Thickness(10, imgMargin, 0, 0);
                img.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                img.Source = new BitmapImage(new Uri(t.image, UriKind.Absolute));
                ContentPanel.Children.Add(img);

                //<TextBlock HorizontalAlignment="Left" Margin="100,6,-11,0" TextWrapping="Wrap" Text="The Bonzo Dog Doo Dah Band " VerticalAlignment="Top" Width="367" Height="26"/>
                //<TextBlock HorizontalAlignment="Left" Margin="100,114,-11,0" TextWrapping="Wrap" Text="The Bonzo Dog Doo Dah Band " VerticalAlignment="Top" Width="367" Height="26"/>
                TextBlock tb = new TextBlock();
                tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                tb.Height = 26;
                tb.Width = 367;
                tb.Margin = new Thickness(100, tb1Margin, -11, 0);
                tb.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                tb.TextWrapping = TextWrapping.Wrap;
                tb.Text = t.artist;
                ContentPanel.Children.Add(tb);

                //<TextBlock HorizontalAlignment="Left" Margin="100,35,-11,0" TextWrapping="Wrap" Text="Don't Sit Down Cause I've Moved Your Chair" VerticalAlignment="Top" Width="367" Height="26"/>
                //<TextBlock HorizontalAlignment="Left" Margin="100,143,-11,0" TextWrapping="Wrap" Text="Don't Sit Down Cause I've Moved Your Chair" VerticalAlignment="Top" Width="367" Height="26"/>
                TextBlock tb2 = new TextBlock();
                tb2.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                tb2.Height = 26;
                tb2.Width = 367;
                tb2.Margin = new Thickness(100, tb2Margin, -11, 0);
                tb2.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                tb2.TextWrapping = TextWrapping.Wrap;
                tb2.Text = t.name;
                ContentPanel.Children.Add(tb2);

                //<TextBlock HorizontalAlignment="Left" Margin="100,64,-11,0" TextWrapping="Wrap" Text="1 hour ago" VerticalAlignment="Top" Width="367" Foreground="Gray" Height="26"/>
                //<TextBlock HorizontalAlignment="Left" Margin="100,172,-11,0" TextWrapping="Wrap" Text="1 hour ago" VerticalAlignment="Top" Width="367" Foreground="Gray" Height="26"/>
                TextBlock tb3 = new TextBlock();
                tb3.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                tb3.Height = 26;
                tb3.Width = 367;
                tb3.Margin = new Thickness(100, tb3Margin, -11, 0);
                tb3.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                tb3.TextWrapping = TextWrapping.Wrap;
                tb3.Text = t.date;
                tb3.Foreground = new SolidColorBrush(Colors.Gray);
                ContentPanel.Children.Add(tb3);

                imgMargin += 108;
                tb1Margin += 108;
                tb2Margin += 108;
                tb3Margin += 108;
            }

            SystemTray.ProgressIndicator.IsIndeterminate = false;
            SystemTray.ProgressIndicator.IsVisible = false;
        }
    }
}