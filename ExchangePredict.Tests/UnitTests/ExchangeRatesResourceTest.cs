namespace ExchangePredict.Tests.UnitTests
{
    using ExchangePredict.BuildBlocks.Configuration;
    using ExchangePredict.BuildBlocks.Constracts;
    using ExchangePredict.BuildBlocks.Services;
    using ExchangePredict.Tests.Helpers;
    using FluentAssertions;
    using Microsoft.Extensions.Options;
    using Moq;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;

    public class ExchangeRatesResourceTest
    {
        [Fact]
        public async Task GetHistoricalDataShouldReturnListOfExchangeRates()
        {
            var httpClientFactory = new Mock<IHttpClientFactory>();
            var options = new Mock<IOptions<ExchangeRatesResourceConfiguration>>();
            var json = "{}";
            var httpClient = HttpClientMockHelper.CreateHttpClient(json);

            var configuration = new ExchangeRatesResourceConfiguration
            {
                Endpoint = "https://gogle.com",
                AppId = "12345"
            };

            options.Setup(t => t.Value).Returns(configuration);
            httpClientFactory
                .Setup(t => t.CreateClient(It.IsAny<string>()))
                .Returns(httpClient);

            IExchangeRatesResource exchangeRate = new ExchangeRatesResource(httpClientFactory.Object, options.Object);
            var targetDate = new DateTime(2017, 1, 15);

            // Actions
            var historicalData = await exchangeRate.GetHistorical(targetDate);

            // Assertsions
            historicalData.Should().NotBeNull();
        }
    }
}
