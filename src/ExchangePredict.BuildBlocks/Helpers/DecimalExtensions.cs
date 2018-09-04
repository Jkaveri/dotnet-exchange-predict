namespace System
{
    public static class DecimalExtensions
    {
        public static bool AlmostEquals(this decimal value1, decimal value2, int precision)
        {
            return value1 == value2 ||
                Math.Round(Math.Abs(value1 - value2), precision) == 0;
        }
    }
}
