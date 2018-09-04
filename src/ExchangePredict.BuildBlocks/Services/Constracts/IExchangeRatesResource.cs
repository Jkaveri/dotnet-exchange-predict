namespace ExchangePredict.BuildBlocks.Services.Constracts
{
    using ExchangePredict.BuildBlocks.Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IExchangeRatesResource
    {
        Task<ExchangeRate> GetHistorical(
            DateTime targetDate,
            string baseCurrency,
            string[] targetCurrency,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
