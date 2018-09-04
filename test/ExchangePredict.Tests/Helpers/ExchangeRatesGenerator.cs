namespace ExchangePredict.Tests.Helpers
{
    using ExchangePredict.BuildBlocks.Models;
    using System;
    using System.Collections.Generic;

    public static class ExchangeRatesGenerator
    {
        public static List<ExchangeRate> GenerateExchangeRates(DateTime targetDate, List<decimal> rates)
        {
            var samples = new List<ExchangeRate>();
            DateTime date;
            ExchangeRate exchangeRateItem;
            for (var i = 1; i < 13; i++)
            {
                date = targetDate.AddMonths(-1 * i);
                Dictionary<string, decimal> ratesMap = new Dictionary<string, decimal>
                {
                    { "TRY", rates[i - 1] }
                };
                exchangeRateItem = new ExchangeRate(
                    date,
                    rates: ratesMap);

                samples.Add(exchangeRateItem);
            }

            return samples;
        }
    }
}
