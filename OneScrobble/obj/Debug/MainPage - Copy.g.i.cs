﻿#pragma checksum "C:\Users\Vitor\SkyDrive\Windows Phone Projects\OneScrobble\OneScrobble\MainPage - Copy.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "19C268B9CDEDF2CAE3A94F02A65C98CF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace OneScrobble {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock OneScrobble;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Button SignIn;
        
        internal System.Windows.Controls.TextBox UsernameTextBox;
        
        internal System.Windows.Controls.TextBox PasswordTextBox;
        
        internal System.Windows.Controls.TextBlock UsernameTextBlock;
        
        internal System.Windows.Controls.TextBlock PasswordTextBlock;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/OneScrobble;component/MainPage%20-%20Copy.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.OneScrobble = ((System.Windows.Controls.TextBlock)(this.FindName("OneScrobble")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.SignIn = ((System.Windows.Controls.Button)(this.FindName("SignIn")));
            this.UsernameTextBox = ((System.Windows.Controls.TextBox)(this.FindName("UsernameTextBox")));
            this.PasswordTextBox = ((System.Windows.Controls.TextBox)(this.FindName("PasswordTextBox")));
            this.UsernameTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("UsernameTextBlock")));
            this.PasswordTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("PasswordTextBlock")));
        }
    }
}

