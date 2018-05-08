using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ImageCollector.Services.Abstractions
{
    public abstract class CollectionServiceBase : ICollectionService
    {
        public CollectionServiceBase(
            IOptions<CollectionServiceOptions> options,
            ILoggerFactory loggerFactory)
        {
            this.baseUrl = options.Value.BaseUrl;
            this.getUrl = options.Value.GetUrl;
            this.authenticationHeaders = options.Value.AuthenticationHeader;
            this.getParameters = options.Value.GetParameters;

            this.logger = loggerFactory.CreateLogger<CollectionServiceBase>();
        }

        public string BaseUrl { get => baseUrl; }

        public T GetData<T>()
        {
            T result = GetDataAsync<T>().Result;

            return result;
        }

        public abstract Task<T> GetDataAsync<T>();

        protected string GetDataUrl
        {
            get => $"{baseUrl}{getUrl}";
        }

        protected IDictionary<string, string> AuthenticationHeaders
        {
            get => authenticationHeaders;
        }

        protected IDictionary<string, string> GetParameters
        {
            get => getParameters;
        }

        private string baseUrl;
        private string getUrl;
        private IDictionary<string, string> authenticationHeaders;
        private IDictionary<string, string> getParameters;
        private readonly ILogger logger;
    }
}
