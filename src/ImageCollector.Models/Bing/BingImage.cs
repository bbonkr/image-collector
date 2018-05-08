using System;
using System.Collections.Generic;
using System.Text;

namespace ImageCollector.Models.Bing
{
    public class BingImage
    {
        public string Startdata { get; set; }

        public string Fullstartdate { get; set; }

        public string Enddate { get; set; }

        public string Url { get; set; }

        public string Urlbase { get; set; }

        public string Copyright { get; set; }

        public string Copyrightlink { get; set; }

        public string Quiz { get; set; }

        public bool Wp { get; set; }

        public string Hsh { get; set; }

        public int Drk { get; set; }

        public int Top { get; set; }

        public int Bot { get; set; }

        public IList<string> Hs { get; set; }
    }
}
