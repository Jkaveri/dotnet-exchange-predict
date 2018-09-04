namespace ExchangePredict.Tests.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ExchangePredict.BuildBlocks.Models;
    using ExchangePredict.BuildBlocks.Services;
    using ExchangePredict.BuildBlocks.Services.Constracts;
    using FluentAssertions;
    using Xunit;

    public class ExchangeRatePredictorTest
    {
        [Fact]
        public async Task PredictShouldCorrect()
        {
            IExchangeRatePredictor predictor = new ExchangeRatePredictor();
            var targetDate = new DateTime(2017, 1, 15);
            var samples = GenerateExchangeRates(targetDate);

            decimal expectedResult = 3.1m;

            // Actions
            var result = await predictor.Predict(samples, targetDate);

            result.Should().Be(expectedResult);
        }

        private List<ExchangeRate> GenerateExchangeRates(DateTime targetDate)
        {
            var samples = new List<ExchangeRate>();
            DateTime date;
            ExchangeRate exchangeRateItem;
            for (var i = 1; i < 13; i++)
            {
                date = targetDate.AddMonths(-1 * i);
                Dictionary<string, decimal> rates = new Dictionary<string, decimal>
                {
                    { "TRY", 3 }
                };
                exchangeRateItem = new ExchangeRate(
                    date,
                    rates: rates);

                samples.Add(exchangeRateItem);
            }

            return samples;
        }
    }
}
