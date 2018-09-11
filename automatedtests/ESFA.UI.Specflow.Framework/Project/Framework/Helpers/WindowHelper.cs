using System;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace ESFA.UI.Specflow.Framework.FindACourse.Project.Framework.Helpers
{
    public class WindowHelper
    {
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
            webDriver.Close();
            webDriver.SwitchTo().Window(newWindowHandle);
        }

        public static void SwitchToDefaultWindow(IWebDriver webDriver)
        {
            webDriver.SwitchTo().DefaultContent();
            Console.WriteLine(" window url = " + webDriver.Url);
        }
    }
}