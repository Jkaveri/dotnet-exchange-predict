namespace ExchangePredict.BuildBlocks.Constracts
{
    using ExchangePredict.BuildBlocks.Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IExchangeRatesResource
    {
        Task<ExchangeRate> GetHistorical(
            DateTime targetDate,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
