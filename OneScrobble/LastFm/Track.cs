using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneScrobble
{
    class Track
    {
        public string artist { get; set; }
        public string name { get; set; }
        public string album { get; set; }
        public string url { get; set; }
        public string image { get; set; }
        public string date { get; set; }

        public Track(string artist, string name, string album, string url, string image, string date)
        {
            this.artist = artist;
            this.name = name;
            this.album = album;
            this.url = url;
            this.image = image;
            this.date = date;
        }

        public override string ToString() {
            return this.artist + " - " + this.name;
        }
    }
}
