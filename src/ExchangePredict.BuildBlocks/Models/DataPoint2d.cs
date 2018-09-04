namespace ExchangePredict.BuildBlocks.Models
{
    public class DataPoint2D
    {
        public DataPoint2D(int x, decimal y)
        {
            X = x;
            Y = y;
        }

        public decimal X { get; set; }
        public decimal Y { get; set; }
    }
}
