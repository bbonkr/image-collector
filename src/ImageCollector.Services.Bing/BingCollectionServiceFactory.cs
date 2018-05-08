using System;
using System.Collections.Generic;
using System.Text;
using ImageCollector.Infrastructure;
using ImageCollector.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ImageCollector.Services.Bing
{
    public class BingCollectionServiceFactory
    { 
        public BingCollectionServiceFactory()
        {
                 
        }

        public ICollectionService Create()
        {
            DependancyManager.Instance.ServiceCollection.AddTransient<ICollectionService, CollectionService>();

        }
    }
}
