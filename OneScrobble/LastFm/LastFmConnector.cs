using Microsoft.Phone.Shell;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace OneScrobble.LastFm
{
    public class LastFmConnector
    {
        public static string lastFmApiUrl { get; set; }
        public static string lastFmApiKey { get; set; }
        public static string lastFmApiSig { get; set; }
        public static string lastFmSecret { get; set; }
        public static string lastFmSessionKey { get; set; }
        public static string lastFmUsername { get; set; }

        static LastFmConnector()
        {
            lastFmApiUrl = "https://ws.audioscrobbler.com/2.0/";
            lastFmApiKey = "e78fe90a4362a30056e444c80d5c9386";
            lastFmApiSig = string.Empty;
            lastFmSecret = "4ad5154ec9ecd3db0a30ffbb0e7cc428";
            lastFmSessionKey = string.Empty;
            lastFmUsername = string.Empty;
        }

        protected async Task WebServiceCall(string postData)
        {
            byte[] requestBody = Encoding.UTF8.GetBytes(postData);

            HttpWebRequest request = WebRequest.Create(lastFmApiUrl) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            using (var postStream = await request.GetRequestStreamAsync())
            {
                await postStream.WriteAsync(requestBody, 0, requestBody.Length);
            }

            var response = (HttpWebResponse) await request.GetResponseAsync();

            if (response != null) {
                var reader = new StreamReader(response.GetResponseStream());
                string responseString = await reader.ReadToEndAsync();
                JObject responseJson = JsonConvert.DeserializeObject(responseString) as JObject;
                WebServiceCallback(responseJson);
            }

            SystemTray.ProgressIndicator.IsIndeterminate = false;
            SystemTray.ProgressIndicator.IsVisible = false;
        }

        protected virtual void WebServiceCallback(JObject response) { }
    }
}
