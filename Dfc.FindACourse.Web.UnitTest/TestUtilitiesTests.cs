using System;
using Dfc.FindACourse.TestUtilities.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dfc.FindACourse.Web.UnitTest
{
    [TestClass]
    public class TestUtilitiesTests
    {
        [TestMethod]
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
