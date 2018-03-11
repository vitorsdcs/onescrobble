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
using Microsoft.Phone.Scheduler;
using System.Diagnostics;
using System.Windows.Media;

namespace OneScrobble
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            SystemTray.ProgressIndicator = new ProgressIndicator();
            SystemTray.ProgressIndicator.IsIndeterminate = true;
            SystemTray.ProgressIndicator.IsVisible = true;
            SystemTray.ProgressIndicator.Text = "Signing in...";

            SignIn.IsEnabled = false;
            UsernameTextBox.IsEnabled = false;
            PasswordTextBox.IsEnabled = false;

            new AuthGetMobileSession("vtttr", "x20138607");
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SignIn.IsEnabled = !string.IsNullOrWhiteSpace(UsernameTextBox.Text) &&
                               !string.IsNullOrWhiteSpace(PasswordTextBox.Text);
        }

        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SignIn.IsEnabled = !string.IsNullOrWhiteSpace(UsernameTextBox.Text) &&
                               !string.IsNullOrWhiteSpace(PasswordTextBox.Text);
        }
    }
}