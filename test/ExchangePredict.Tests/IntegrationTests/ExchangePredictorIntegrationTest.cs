namespace ExchangePredict.Tests.IntegrationTests
{
    using ExchangePredict.BuildBlocks.Configuration;
    using ExchangePredict.BuildBlocks.Services;
    using ExchangePredict.BuildBlocks.Services.Constracts;
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class ExchangePredictorIntegrationTest
    {
        [Fact]
        public async Task PredictShouldWork()
        {
            var services = new ServiceCollection();
            services.AddExchangePredict(opts =>
            {
                opts.Endpoint = "https://openexchangerates.org/api/";
                opts.AppId = "573c0c9d12e14355b304fcf52e240699";
            });
            var sp = services.BuildServiceProvider();
            var predictor = sp.GetService<IExchangeRatePredictor>();

            var targetDate = new DateTime(2017, 1, 15);
            var expectedResult = 3.263m;
            var result = await predictor.PredictAsync("USD", "TRY", targetDate, 12);

            result.AlmostEquals(expectedResult, 3).Should().BeTrue();
        }
    }
}
