using System;
using Microsoft.Extensions.DependencyInjection;

namespace ImageCollector.Infrastructure
{
    public class DependancyManager
    {
        private DependancyManager()
        {
            serviceCollection = new ServiceCollection();
        }

        public static DependancyManager Instance
        {
            get
            {
                if(instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new DependancyManager();
                        }
                    }
                }

                return instance;
            }
        }

        public IServiceCollection ServiceCollection
        {
            get => serviceCollection;
        }

        public IServiceProvider ServiceProvider
        {
            get => serviceProvider;
        }

        public void BuildServiceProvider()
        {
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private static volatile DependancyManager instance = null;
        private static object syncRoot = new object();

        private IServiceCollection serviceCollection;
        private IServiceProvider serviceProvider;
    }
}
