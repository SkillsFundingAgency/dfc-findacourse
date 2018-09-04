using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;

namespace ESFA.UI.Specflow.Framework.FindACourse.Project.Framework.Helpers
{
    public class SwitchWindowHelper
    {
        //protected static IWebDriver webDriver;
       // private static string mainWindowHandle = webDriver.CurrentWindowHandle;


         public static void SwitchToNewWindow(IWebDriver webDriver)
        {
            webDriver.SwitchTo().DefaultContent();
            string mainWindowHandle = webDriver.CurrentWindowHandle;
            ReadOnlyCollection<string> windowHandles = webDriver.WindowHandles;
            String newWindowHandle = "";
            foreach (string handle in windowHandles)
            {
                if (handle != mainWindowHandle)
                {
                    newWindowHandle = handle;
                    break;
                }
            }

            webDriver.SwitchTo().Window(newWindowHandle);
        }

        public static void SwitchToDefaultWindow(IWebDriver webDriver)
        {
            webDriver.SwitchTo().DefaultContent();
            Console.WriteLine(" window url = " + webDriver.Url);
        }
    }
}