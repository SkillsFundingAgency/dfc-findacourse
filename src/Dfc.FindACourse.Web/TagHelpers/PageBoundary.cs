using System;

namespace Dfc.FindACourse.Web.TagHelpers
{
    public class PageBoundary
    {
        public int StartNumber { get; }
        public int DisplayNumber { get; }

        public PageBoundary(bool isSlider, int noOfPages, int displayNoOfPages, int currentPageNo)
        {
            StartNumber = 1;
            DisplayNumber = noOfPages < displayNoOfPages ? noOfPages : displayNoOfPages;

            if (!isSlider) return;

            var ceiling = (int)Math.Ceiling((decimal)DisplayNumber / 2);

            if (ceiling > currentPageNo) return;

            StartNumber = currentPageNo + 1 - ceiling;
            DisplayNumber = (DisplayNumber - 1 + StartNumber) < noOfPages ? (DisplayNumber - 1 + StartNumber): noOfPages;
        }
    }
}