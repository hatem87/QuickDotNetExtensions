namespace QuickDotNetExtensions.UnitTests
{
    public class EnumerableExtensionsTests
    {
        /**********************************************************************************/
        /********************************** IsNullOrEmpty *********************************/
        /**********************************************************************************/
        [Fact]
        public void EnumerableExtensions_IsNullOrEmpty_Should_ReturnTrue_When_SourceIsNull()
        {
            IEnumerable<object> source = null!;
            Assert.True(source.IsNullOrEmpty());
        }

        [Fact]
        public void EnumerableExtensions_IsNullOrEmpty_Should_ReturnTrue_When_SourceIsEmpty()
        {
            IEnumerable<object> source = new List<object>();
            Assert.True(source.IsNullOrEmpty());
        }

        [Fact]
        public void EnumerableExtensions_IsNullOrEmpty_Should_ReturnFalse_When_SourceIsNotEmpty()
        {
            IEnumerable<object> source = new List<object>() { new { Name = "hatem" } };
            Assert.False(source.IsNullOrEmpty());
        }

        /**********************************************************************************/
        /************************************** Page **************************************/
        /**********************************************************************************/
        [Fact]
        public void EnumerableExtensions_Page_Should_Throw_When_SourceIsNull()
        {
            IEnumerable<object> source = null!;
            Assert.Throws<ArgumentNullException>(() => source.Page(1, 1000));
        }

        [Fact]
        public void EnumerableExtensions_Page_Should_Throw_When_PageNumberIsNegative()
        {
            IEnumerable<int> source = new List<int>() { 1, 2, 3 };
            Assert.Throws<ArgumentException>(() => source.Page(-3, 2));
        }

        [Fact]
        public void EnumerableExtensions_Page_Should_Throw_When_PageSizeIsZero()
        {
            IEnumerable<int> source = new List<int>() { 1, 2, 3 };
            Assert.Throws<ArgumentException>(() => source.Page(1, 0));
        }

        [Fact]
        public void EnumerableExtensions_Page_Should_Throw_When_PageSizeIsNegative()
        {
            IEnumerable<int> source = new List<int>() { 1, 2, 3 };
            Assert.Throws<ArgumentException>(() => source.Page(1, -10));
        }

        [Fact]
        public void EnumerableExtensions_Page_Should_ReturnTheFirsttPage_When_FirstPageRequested()
        {
            IEnumerable<int> source = new List<int>() { /* first page */ 1, 2, 3, 4, 5, /* second page */ 6, 7, 8, 9, 10, /* third page */ 11, 12, 13, 14, 15, /* last page */ 16, 17 };
            var page = source.Page(1, 5).ToList();
            Assert.True(!page.IsNullOrEmpty());
            Assert.Equal(5, page.Count());
            Assert.Equal(1, page[0]);
            Assert.Equal(2, page[1]);
            Assert.Equal(3, page[2]);
            Assert.Equal(4, page[3]);
            Assert.Equal(5, page[4]);
        }

        [Fact]
        public void EnumerableExtensions_Page_Should_ReturnTheLastPage_When_LastPageRequested()
        {
            IEnumerable<int> source = new List<int>() { /* first page */ 1, 2, 3, 4, 5, /* second page */ 6, 7, 8, 9, 10, /* third page */ 11, 12, 13, 14, 15, /* last page */ 16, 17 };
            var page = source.Page(4, 5).ToList();
            Assert.True(!page.IsNullOrEmpty());
            Assert.Equal(2, page.Count());
            Assert.Equal(16, page[0]);
            Assert.Equal(17, page[1]);
        }

        [Fact]
        public void EnumerableExtensions_Page_Should_ReturnTheRightPage_When_AnyPageRequested()
        {
            IEnumerable<int> source = new List<int>() { /* first page */ 1, 2, 3, 4, 5, /* second page */ 6, 7, 8, 9, 10, /* third page */ 11, 12, 13, 14, 15, /* last page */ 16, 17 };
            var page = source.Page(2, 5).ToList();
            Assert.True(!page.IsNullOrEmpty());
            Assert.Equal(5, page.Count());
            Assert.Equal(6, page[0]);
            Assert.Equal(7, page[1]);
            Assert.Equal(8, page[2]);
            Assert.Equal(9, page[3]);
            Assert.Equal(10, page[4]);
        }

        /**********************************************************************************/
        /************************************** Batch *************************************/
        /**********************************************************************************/
        [Fact]
        public void EnumerableExtensions_Batch_Should_Throw_When_SourceIsNull()
        {
            IEnumerable<object> source = null!;
            Assert.Throws<ArgumentNullException>(() => source.Batch(1000));
        }

        [Fact]
        public void EnumerableExtensions_Batch_Should_Throw_When_BatchSizeIsZero()
        {
            IEnumerable<int> source = new List<int>() { 1, 2, 3 };
            Assert.Throws<ArgumentException>(() => source.Batch(0));
        }

        [Fact]
        public void EnumerableExtensions_Batch_Should_Throw_When_BatchSizeIsNegative()
        {
            IEnumerable<int> source = new List<int>() { 1, 2, 3 };
            Assert.Throws<ArgumentException>(() => source.Batch(-10));
        }

        [Fact]
        public void EnumerableExtensions_Batch_Should_ReturnListOfList_When_Requested()
        {
            IEnumerable<int> source = new List<int>() { /* first page */ 1, 2, 3, 4, 5, /* second page */ 6, 7, 8, 9, 10, /* last page */ 11, 12 };
            var page = source.Batch(5).ToList();
            Assert.True(!page.IsNullOrEmpty());
            Assert.Equal(3, page.Count()); // They should be 3 pages

            var fristPage = page[0].ToList();
            Assert.Equal(1, fristPage[0]);
            Assert.Equal(2, fristPage[1]);
            Assert.Equal(3, fristPage[2]);
            Assert.Equal(4, fristPage[3]);
            Assert.Equal(5, fristPage[4]);

            var secondPage = page[1].ToList();
            Assert.Equal(6, secondPage[0]);
            Assert.Equal(7, secondPage[1]);
            Assert.Equal(8, secondPage[2]);
            Assert.Equal(9, secondPage[3]);
            Assert.Equal(10, secondPage[4]);

            var lastPage = page[2].ToList();
            Assert.Equal(11, lastPage[0]);
            Assert.Equal(12, lastPage[1]);
        }

        [Fact]
        public void EnumerableExtensions_Batch_Should_ReturnListOfOneList_When_BatchSizeIsGreaterThanSourceSize()
        {
            IEnumerable<int> source = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var page = source.Batch(1777).ToList();
            Assert.True(!page.IsNullOrEmpty());
            Assert.Single(page); // They should be only 1 page as the page size > source size

            var fristPage = page[0].ToList();
            Assert.Equal(1, fristPage[0]);
            Assert.Equal(12, fristPage[11]);
        }
    }
}
