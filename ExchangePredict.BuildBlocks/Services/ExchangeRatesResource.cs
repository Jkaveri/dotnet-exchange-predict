namespace ExchangePredict.BuildBlocks.Services
{
    using ExchangePredict.BuildBlocks.Configuration;
    using ExchangePredict.BuildBlocks.Constracts;
    using ExchangePredict.BuildBlocks.Models;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class ExchangeRatesResource : IExchangeRatesResource
    {
        private readonly ExchangeRatesResourceConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public ExchangeRatesResource(IHttpClientFactory httpClientFactory, IOptions<ExchangeRatesResourceConfiguration> options)
        {
            _configuration = options.Value ?? throw new ArgumentNullException(nameof(options));
            if (httpClientFactory == null)
            {
                throw new ArgumentNullException(nameof(httpClientFactory));
            }

            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(_configuration.Endpoint);
        }

        public async Task<ExchangeRate> GetHistorical(DateTime targetDate, CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = _httpClientFactory.CreateClient();
            var dateStr = targetDate.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("us"));
            var url = BuildUrl($"historical/{dateStr}.json");
            return await client.GetAsync<ExchangeRate>(url, cancellationToken).ConfigureAwait(false);
        }

        private string BuildUrl(string path, Dictionary<string, string> @params = null)
        {
            var query = string.Empty;

            if (@params != null)
            {
                var paramList = @params.Select(
                    item => $"{item.Key}={Uri.EscapeDataString(item.Value)}");
                query = string.Join("&", paramList);
                query = "?" + query;
            }

            return $"/{path}{query}";
        }
    }
}
