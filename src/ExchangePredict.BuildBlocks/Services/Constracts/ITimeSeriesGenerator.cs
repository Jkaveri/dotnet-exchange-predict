namespace ExchangePredict.BuildBlocks.Services.Constracts
{
    using System;
    using System.Collections.Generic;

    public interface ITimeSeriesGenerator
    {
        IEnumerable<DateTime> MoveBackwardByMonth(DateTime targetDate, int count, bool includeTargetDate);
    }
}
