using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OneScrobble.LastFm
{
    class UserGetRecentTracks : LastFmConnector
    {
        private int limit;
        private string method;
        private string format;
        private Action callback;
        public JObject recentTracks { get; set; }

        public UserGetRecentTracks(int limit, Action callback)
        {
            this.limit = limit;
            this.method = "user.getRecentTracks";
            this.format = "json";
            this.callback = callback;

            StringBuilder postData = new StringBuilder();
            postData.Append(String.Format("method={0}&", this.method));
            postData.Append(String.Format("user={0}&", LastFmConnector.lastFmUsername));
            postData.Append(String.Format("api_key={0}&", LastFmConnector.lastFmApiKey));
            postData.Append(String.Format("api_sig={0}&", LastFmConnector.lastFmApiSig));
            postData.Append(String.Format("sk={0}&", LastFmConnector.lastFmSessionKey));
            postData.Append(String.Format("limit={0}&", this.limit));
            postData.Append(String.Format("format={0}", this.format));

            base.WebServiceCall(postData.ToString());
        }

        protected override void WebServiceCallback(JObject response)
        {
            this.recentTracks = response;
            this.callback();
        }
    }
}
