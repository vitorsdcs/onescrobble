using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace OneScrobble.LastFm
{
    class AuthGetMobileSession : LastFmConnector
    {
        private string password;
        private string method;
        private string format;

        public AuthGetMobileSession(string username, string password)
        {
            LastFmConnector.lastFmUsername = username;
            this.password = password;
            this.method = "auth.getMobileSession";
            this.format = "json";
            BuildApiSig();

            StringBuilder postData = new StringBuilder();
            postData.Append(String.Format("method={0}&", this.method));
            postData.Append(String.Format("username={0}&", LastFmConnector.lastFmUsername));
            postData.Append(String.Format("password={0}&", this.password));
            postData.Append(String.Format("api_key={0}&", LastFmConnector.lastFmApiKey));
            postData.Append(String.Format("api_sig={0}&", LastFmConnector.lastFmApiSig));
            postData.Append(String.Format("format={0}", this.format));

            base.WebServiceCall(postData.ToString());
        }

        private void BuildApiSig()
        {
            StringBuilder apiSig = new StringBuilder();
            apiSig.Append("api_key");
            apiSig.Append(LastFmConnector.lastFmApiKey);
            apiSig.Append("method");
            apiSig.Append(this.method);
            apiSig.Append("password");
            apiSig.Append(this.password);
            apiSig.Append("username");
            apiSig.Append(LastFmConnector.lastFmUsername);
            apiSig.Append(LastFmConnector.lastFmSecret);

            MD5.MD5 md = new MD5.MD5();
            md.Value = apiSig.ToString();
            LastFmConnector.lastFmApiSig = md.FingerPrint.ToLower();
        }

        protected override void WebServiceCallback(JObject response)
        {
            LastFmConnector.lastFmSessionKey = (string) response["session"]["key"];
            (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/RecentTracks.xaml", UriKind.Relative));
        }
    }
}
