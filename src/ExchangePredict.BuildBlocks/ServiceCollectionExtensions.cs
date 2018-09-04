namespace Microsoft.Extensions.DependencyInjection
{
    using ExchangePredict.BuildBlocks.Configuration;
    using ExchangePredict.BuildBlocks.Services;
    using ExchangePredict.BuildBlocks.Services.Constracts;
    using System;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddExchangePredict(this IServiceCollection services, Action<ExchangeRatesResourceConfiguration> configure)
        {

            services.Configure(configure);
            services.AddSingleton<ITimeSeriesGenerator, TimeSeriesGenerator>();
            services.AddTransient<IExchangeRatesResource, ExchangeRatesResource>();
            services.AddTransient<IExchangeRatePredictor, ExchangeRatePredictor>();
            services.AddTransient<IRegressionEquationFactory, RegressionEquationFactory>();
            services.AddHttpClient();
            return services;
        }
    }
}
