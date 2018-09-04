namespace ExchangePredict.BuildBlocks.Services.Constracts
{
    using ExchangePredict.BuildBlocks.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IExchangeRatePredictor
    {
        Task<decimal> PredictAsync(string from, string to, DateTime targetDate, int numOfSamples = 12);
    }
}
