namespace ExchangePredict.BuildBlocks.Services.Constracts
{
    using System.Collections.Generic;
    using ExchangePredict.BuildBlocks.Models;

    public interface IRegressionEquationFactory
    {
        RegressionEquation Create(List<DataPoint2D> samples);
    }
}
