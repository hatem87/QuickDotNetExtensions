namespace QuickDotNetExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns sequence of string between the firstSequence and the secondSequence
        /// </summary>
        /// <param name="source"></param>
        /// <param name="firstSequence"></param>
        /// <param name="secondSequence"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string Between(this string? source, string firstSequence, string secondSequence)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
           
            int firstPosition = source.IndexOf(firstSequence) + firstSequence.Length;
            int secondPosition = source.IndexOf(secondSequence);
            string finalString = source.Substring(firstPosition, secondPosition - firstPosition);
            return finalString;
        }

        /// <summary>
        /// Compares to a string and ignore case (case insensitive).
        /// Culture is InvariantCulture
        /// </summary>
        /// <param name="source"></param>
        /// <param name="secondString"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool EqualsIgnoreCase(this string? source, string secondString)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return string.Equals(source, secondString, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Returns the sequence in the left side of the string before reaching the indicated length
        /// </summary>
        /// <param name="source"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string Left(this string? source, int length)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (length <= source.Length)
                return source.Substring(0, length);

            return source;
        }

        /// <summary>
        /// Returns the sequence in the right side of the string starting from the indicated length.
        /// Throws exception if the indicated lenght is greater than the string length
        /// </summary>
        /// <param name="source"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static string Right(this string? source, int length)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (length > source.Length)
                throw new ArgumentException("Length is greater than the string length.");

            return source.Substring(source.Length - length);
        }
    }
}