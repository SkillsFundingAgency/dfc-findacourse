using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Dfc.FindACourse.Common.Models
{
    public class PagingOptions : ValueObject<PagingOptions>, IPagingOptions
    {
        public SortBy SortBy { get; }
        public int PageNo { get; }

        public PagingOptions(SortBy sortBy, int pageNo)
        {
            if (!Enum.IsDefined(typeof(SortBy), sortBy))
                throw new ArgumentOutOfRangeException(nameof(sortBy));
            if (pageNo < 0)
                throw new ArgumentOutOfRangeException(nameof(pageNo));

            SortBy = sortBy;
            PageNo = pageNo;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return SortBy;
            yield return PageNo;
        }
    }
}