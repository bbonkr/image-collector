using System;
using System.Collections.Generic;
using System.Text;

namespace ImageCollector.Services.Abstractions
{
    public class CollectionServiceOptions
    {
        public string BaseUrl { get; set; }

        public string GetUrl { get; set; }

        public IDictionary<string, string> AuthenticationHeader { get; set; } = new Dictionary<string, string>();

        public IDictionary<string, string> GetParameters { get; set; } = new Dictionary<string, string>();
    }
}
