using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Dfc.FindACourse.TestUtilities
{
    namespace TestUtilities
    {
        public static class ComparisonsExtensions
        {
            public static void Exception<T>(Action action, string expectedMessage) where T : Exception
            {
                try
                {
                    action.Invoke();
                    Assert.Fail("Exception of type {0} should be thrown.", typeof(T));
                }
                catch (T exc)
                {
                    Assert.AreEqual(expectedMessage, exc.Message);
                }
            }

            public static void IsSame<T>(this T expected, T actual)
            {
                var a = JsonConvert.SerializeObject(expected);
                var b = JsonConvert.SerializeObject(actual);

                Assert.AreEqual(a, b);
            }
        }
    }
}
