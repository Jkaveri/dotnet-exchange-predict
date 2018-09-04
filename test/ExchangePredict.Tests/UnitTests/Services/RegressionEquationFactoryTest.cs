namespace ExchangePredict.Tests.UnitTests.Services
{
    using ExchangePredict.BuildBlocks.Models;
    using ExchangePredict.BuildBlocks.Services;
    using ExchangePredict.BuildBlocks.Services.Constracts;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class RegressionEquationFactoryTest
    {
        [Fact]
        public void CreateCorrectRegressionEquation()
        {
            IRegressionEquationFactory factory = new RegressionEquationFactory();
            var targetDate = new DateTime(2017, 1, 17);
            var samples = new List<DataPoint2D>
            {
                new DataPoint2D(1, 3.04359m),
                new DataPoint2D(2, 2.945926m),
                new DataPoint2D(3, 2.893866m),
                new DataPoint2D(4, 2.854589m),
                new DataPoint2D(5, 2.970913m),
                new DataPoint2D(6, 2.925991m),
                new DataPoint2D(7, 2.990882m),
                new DataPoint2D(8, 2.944941m),
                new DataPoint2D(9, 2.970704m),
                new DataPoint2D(10, 3.089218m),
                new DataPoint2D(11, 3.284672m),
                new DataPoint2D(12, 3.503773m)
            };
            var expectedSlope = 0.035m;
            var expectedIntercept = 2.807m;

            // Actions
            RegressionEquation regressionEquation = factory.Create(samples);

            // Asse
            regressionEquation.Should().NotBeNull();
            regressionEquation.Intercept
                .AlmostEquals(expectedIntercept, 3)
                .Should().BeTrue();

            regressionEquation.Slope
                .AlmostEquals(expectedSlope, 3)
                .Should().BeTrue();
        }
    }
}
