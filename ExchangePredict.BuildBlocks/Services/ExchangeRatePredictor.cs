namespace ExchangePredict.BuildBlocks.Services
{
    using ExchangePredict.BuildBlocks.Models;
    using ExchangePredict.BuildBlocks.Services.Constracts;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ExchangeRatePredictor : IExchangeRatePredictor
    {
        public Task<decimal> Predict(List<ExchangeRate> samples, DateTime targetDate)
        {
            decimal result = 0;
            return Task.FromResult(result);
        }
    }
}
