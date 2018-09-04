namespace ExchangePredict.BuildBlocks.Services.Constracts
{
    using ExchangePredict.BuildBlocks.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IExchangeRatePredictor
    {
        Task<decimal> Predict(List<ExchangeRate> samples, DateTime targetDate);
        object PredictExchangeRate(object samples, object targetDate);
    }
}
