using System;
using System.Collections.Generic;
using System.Text;

namespace ImageCollector.Models.Bing
{
    public class BingResult
    {
        public BingResult()
        {
            Images = new List<BingImage>();
            Tooltips = new BingTooltips();
        }

        public IList<BingImage> Images { get; set; }

        public BingTooltips Tooltips { get; set; }
    }
}
