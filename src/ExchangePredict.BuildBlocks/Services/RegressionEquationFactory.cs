namespace ExchangePredict.BuildBlocks.Services
{
    using ExchangePredict.BuildBlocks.Models;
    using ExchangePredict.BuildBlocks.Services.Constracts;
    using System.Collections.Generic;

    public class RegressionEquationFactory : IRegressionEquationFactory
    {
        /**
         * Reference: https://www.easycalculation.com/statistics/learn-regression.php
         */
        public RegressionEquation Create(List<DataPoint2D> samples)
        {
            decimal sumX = 0m;
            decimal sumY = 0m;
            decimal sumXY = 0m;
            decimal sumXX = 0m;
            decimal n = samples.Count;

            for (var i = 0; i < n; i++)
            {
                var item = samples[i];

                var x = item.X;
                var y = item.Y;
                sumX += x;
                sumY += y;
                sumXY += x * y;
                sumXX += x * x;
            }

            var slope = ((n * sumXY) - (sumX * sumY)) / ((n * sumXX) - (sumX * sumX));
            var intercept = (sumY - (slope * sumX)) / n;

            return new RegressionEquation(slope, intercept);
        }
    }
}
