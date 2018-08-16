using Dfc.FindACourse.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Dfc.FindACourse.Common.UnitTests.Models
{
    public class PagingOptionsTests
    {
        [Fact]
        public void Constructor_WithSortByAsUndefined_ThrowsArgumentOutOfRangeException()
        {
            //arrange
            var sortBy = 99999;
            var pageNo = 0;

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new PagingOptions((SortBy)sortBy, pageNo));
        }

        [Fact]
        public void Constructor_WithPageNoLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            //arrange
            var sortBy = SortBy.Relevance;
            var pageNo = -1;

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new PagingOptions(sortBy, pageNo));
        }

        [Fact]
        public void Constructor_WithSortByAsDefinedPageNoAsZero_AssignsProperties()
        {
            //arrange
            var sortBy = SortBy.Relevance;
            var pageNo = 0;

            // act 
            var actual = new PagingOptions(sortBy, pageNo);

            // assert
            Assert.Equal(sortBy, actual.SortBy);
            Assert.Equal(pageNo, actual.PageNo);
        }

        [Fact]
        public void Equals_ShouldBeEqual()
        {
            // arrange
            var a = new PagingOptions(SortBy.Distance, 1);
            var b = new PagingOptions(SortBy.Distance, 1);

            // act & assert
            Assert.True(a.Equals(b));
        }

        [Fact]
        public void Equals_ShouldNotBeEqual()
        {
            // arrange
            var a = new PagingOptions(SortBy.StartDate, 2);
            var b = new PagingOptions(SortBy.Distance, 1);

            // act & assert
            Assert.False(a.Equals(b));
        }
    }
}
