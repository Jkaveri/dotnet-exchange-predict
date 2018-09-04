namespace ExchangePredict.BuildBlocks.Helpers
{
    using System;
    using System.Collections.Generic;

    public class TimeSeriesGenerator
    {
        public IEnumerable<DateTime> MoveBackwardByMonth(DateTime targetDate, int count, bool includeTargetDate)
        {
            var startPoint = includeTargetDate ? 0 : 1;
            for (var i = startPoint; i <= count; i++)
            {
                yield return targetDate.AddMonths(-i);
            }
        }
    }
}
