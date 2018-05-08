using System;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ImageCollector.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ImageCollector.Services
{
    public class CollectionService : CollectionServiceBase
    {
        public CollectionService(
            IOptions<CollectionServiceOptions> options,
            ILoggerFactory loggerFactory)
            : base(options, loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger<CollectionService>();

            this.client = new HttpClient();
        }

        public async override Task<T> GetDataAsync<T>()
        {
            T result = default(T);

            string url = this.GetDataUrl;

            if ((GetParameters?.Count ?? 0) > 0)
            {
                StringBuilder query = new StringBuilder();
                url = $"{url}?";

                foreach (var item in GetParameters)
                {
                    query.Append($"{item.Key}={item.Value}&");
                }
                query.Remove(query.Length - 1, 1);

                url = $"{url}{query.ToString()}";
            }

            logger.LogInformation($">>> Request uri: {url}");

            Uri uri = new Uri(url);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

            HttpResponseMessage response = await client.SendAsync(request);

            logger.LogInformation($">>> Response: {response.StatusCode}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    string json = await response.Content.ReadAsStringAsync();

                    result = JsonConvert.DeserializeObject<T>(json);

                    logger.LogInformation($">>> JSON 데이터 변환 완료: type: {typeof(T).GetTypeInfo().FullName}");
                }
                catch (Exception ex)
                {
                    logger.LogWarning($">>> JSON 데이터 처리 실패: type: {typeof(T).GetTypeInfo().FullName}");
                    logger.LogError(ex, ex.Message);
                }
            }
            return result;
        }

        private readonly HttpClient client;
        private readonly ILogger logger;
    }
}
