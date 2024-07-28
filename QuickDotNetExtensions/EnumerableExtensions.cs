namespace QuickDotNetExtensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (pageNumber < 0)
                throw new ArgumentException("Page size cannot be negative.", nameof(pageNumber));

            if (pageSize <= 0)
                throw new ArgumentException("Page size cannot be less than or equal to zero.", nameof(pageSize));

            int skipCount = (pageNumber - 1) * pageSize;
            return source.Skip(skipCount).Take(pageSize);
        }

        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int batchSize)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (batchSize <= 0)
                throw new ArgumentException("Batch size cannot be less than or equal to zero.", nameof(batchSize));

            return source.Select((item, inx) => new { item, inx })
                         .GroupBy(x => x.inx / batchSize)
                         .Select(g => g.Select(x => x.item));
        }
    }
}
