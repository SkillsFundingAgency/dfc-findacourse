using System;
using Dfc.FindACourse.TestUtilities.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace Dfc.FindACourse.Web.UnitTests
{
    [TestClass]
    public class TestUtilitiesTests
    {
        [Fact]
        public void TestExceptionAsExpected()
        {
            var action = new Action(DoWorkWithException);
            ComparisonsExtensions.Exception<Exception>(action, "expected");
        }

        public static void DoWorkWithException()
        {
            throw new Exception("expected");
        }
    }
}
