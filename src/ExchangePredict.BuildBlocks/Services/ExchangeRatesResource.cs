namespace ExchangePredict.BuildBlocks.Services
{
    using ExchangePredict.BuildBlocks.Configuration;
    using ExchangePredict.BuildBlocks.Models;
    using ExchangePredict.BuildBlocks.Services.Constracts;
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
        private const string APP_ID_PARAM = "app_id";
        private readonly ExchangeRatesResourceConfiguration _configuration;
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

        public async Task<ExchangeRate> GetHistorical(
            DateTime targetDate,
            string baseCurrency,
            string[] targetCurrencies,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var dateStr = targetDate.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("us"));
            var @params = new Dictionary<string, string>
                {
                    { "base", baseCurrency },
                    { "symbols", string.Join(',', targetCurrencies) }
                };
            var url = BuildUrl(
                $"historical/{dateStr}.json",
                @params);
            return await _httpClient.GetAsync<ExchangeRate>(url, cancellationToken).ConfigureAwait(false);
        }

        private string BuildUrl(string path, Dictionary<string, string> @params = null)
        {
            if (@params == null)
            {
                @params = new Dictionary<string, string>
                {
                    { APP_ID_PARAM, _configuration.AppId }
                };
            }
            else if (!@params.ContainsKey(APP_ID_PARAM))
            {
                @params.Add(APP_ID_PARAM, _configuration.AppId);
            }

            var paramList = @params.Select(
                    item => $"{item.Key}={Uri.EscapeDataString(item.Value)}");

            var query = "?" + string.Join("&", paramList);

            return $"/{path}{query}";
        }
    }
}
