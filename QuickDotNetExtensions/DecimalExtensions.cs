namespace QuickDotNetExtensions
{
    public static class DecimalExtensions
    {
        public static decimal RoundKeepOneDigit(this decimal value)
        {
            return decimal.Round(value, 1, MidpointRounding.AwayFromZero);
        }

        public static decimal RoundKeepTwoDigits(this decimal value)
        {
            return decimal.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        public static decimal RoundKeepThreeDigits(this decimal value)
        {
            return decimal.Round(value, 3, MidpointRounding.AwayFromZero);
        }

        public static decimal RoundKeepDigits(this decimal value, int digitsToKeep)
        {
            return decimal.Round(value, digitsToKeep, MidpointRounding.AwayFromZero);
        }
    }
}
