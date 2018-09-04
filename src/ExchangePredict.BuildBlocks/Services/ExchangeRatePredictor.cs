namespace ExchangePredict.BuildBlocks.Services
{
    using ExchangePredict.BuildBlocks.Models;
    using ExchangePredict.BuildBlocks.Services.Constracts;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class ExchangeRatePredictor : IExchangeRatePredictor
    {
        private readonly ITimeSeriesGenerator _timeSeriesGenerator;
        private readonly IExchangeRatesResource _exchangeRatesResource;
        private readonly IRegressionEquationFactory _regressionEquationFactory;

        public ExchangeRatePredictor(
            ITimeSeriesGenerator timeSeriesGenerator,
            IExchangeRatesResource exchangeRatesResource,
            IRegressionEquationFactory regressionEquationFactory)
        {
            _timeSeriesGenerator = timeSeriesGenerator;
            _exchangeRatesResource = exchangeRatesResource;
            _regressionEquationFactory = regressionEquationFactory;
        }

        public async Task<decimal> PredictAsync(
            string from,
            string to,
            DateTime targetDate,
            int numOfSamples = 12)
        {
            // generate time series
            var timeSeries = _timeSeriesGenerator
                .MoveBackwardByMonth(targetDate, numOfSamples, false);

            var exchangeRates = await Task.WhenAll(timeSeries.Select(date =>
            {
                return _exchangeRatesResource.GetHistorical(date, from, new[] { to });
            })).ConfigureAwait(false);

            var dataPoints = exchangeRates.Select((xRate, index) =>
            {
                var x = numOfSamples - index;
                var y = xRate.Rates[to];
                return new DataPoint2D(x, y);
            }).ToList();

            var regressionEquation = _regressionEquationFactory.Create(dataPoints);

            decimal result = regressionEquation.Calculate(numOfSamples + 1);

            return result;
        }
    }
}
