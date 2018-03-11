using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Text;

namespace OneScrobble.LastFm
{
    class TrackScrobble : LastFmConnector
    {
        private string artist;
        private string track;
        private int timestamp;
        private string album;
        private int trackNumber;
        private int duration;
        private string method;
        private string format;

        public TrackScrobble(string artist, string track, int timestamp, string album, int trackNumber, int duration)
        {
            this.artist = artist;
            this.track = track;
            this.timestamp = timestamp;
            this.album = album;
            this.trackNumber = trackNumber;
            this.duration = duration;
            this.method = "track.scrobble";
            this.format = "json";
            BuildApiSig();

            StringBuilder postData = new StringBuilder();
            postData.Append(String.Format("artist={0}&", this.artist));
            postData.Append(String.Format("track={0}&", this.track));
            postData.Append(String.Format("timestamp={0}&", this.timestamp));
            postData.Append(String.Format("album={0}&", this.album));
            postData.Append(String.Format("trackNumber={0}&", this.trackNumber));
            postData.Append(String.Format("duration={0}&", this.duration));
            postData.Append(String.Format("method={0}&", this.method));
            postData.Append(String.Format("api_key={0}&", LastFmConnector.lastFmApiKey));
            postData.Append(String.Format("api_sig={0}&", LastFmConnector.lastFmApiSig));
            postData.Append(String.Format("sk={0}&", LastFmConnector.lastFmSessionKey));
            postData.Append(String.Format("format={0}", this.format));
            Debug.WriteLine(postData.ToString());

            base.WebServiceCall(postData.ToString());
        }

        private void BuildApiSig()
        {
            StringBuilder apiSig = new StringBuilder();
            apiSig.Append("album");
            apiSig.Append(this.album);
            apiSig.Append("api_key");
            apiSig.Append(LastFmConnector.lastFmApiKey);
            apiSig.Append("artist");
            apiSig.Append(this.artist);
            apiSig.Append("duration");
            apiSig.Append(this.duration);
            apiSig.Append("method");
            apiSig.Append(this.method);
            apiSig.Append("sk");
            apiSig.Append(LastFmConnector.lastFmSessionKey);
            apiSig.Append("timestamp");
            apiSig.Append(this.timestamp);
            apiSig.Append("track");
            apiSig.Append(this.track);
            apiSig.Append("trackNumber");
            apiSig.Append(this.trackNumber);
            apiSig.Append(LastFmConnector.lastFmSecret);

            MD5.MD5 md = new MD5.MD5();
            md.Value = apiSig.ToString();
            LastFmConnector.lastFmApiSig = md.FingerPrint.ToLower();
        }

        protected override void WebServiceCallback(JObject response)
        {
            Debug.WriteLine(response.ToString());
        }
    }
}
