using Dfc.FindACourse.TestUtilities.TestUtilities;
using Dfc.FindACourse.Web.Models;
using Xunit;

namespace Dfc.FindACourse.Web.xUnit.UnitTests
{
    public class ErrorViewModelTests
    {
        [Fact]
        public void TestGivenNoRequestId()
        {
            const bool expected = false;
            var actual = new ErrorViewModel().ShowRequestId;
            expected.IsSame(actual);
        }

        [Fact]
        public void TestGivenARequestId()
        {
            const bool expected = true;
            var actual = new ErrorViewModel{RequestId = "1"}.ShowRequestId;
            expected.IsSame(actual);
        }

    }

}
