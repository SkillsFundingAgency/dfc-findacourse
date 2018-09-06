using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace ESFA.UI.Specflow.Framework.Project.Framework.Helpers
{
    public class FormCompletionHelper : PageInteractionHelper
    {
         public static void ClickElement(IWebElement element)
        {
            element.Click();
        }

        public static void ClickElement(By locator)
        {
            webDriver.FindElement(locator).Click();
        }

        public static void EnterText(IWebElement element, String text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static void EnterText(By locator, String text)
        {
            webDriver.FindElement(locator).Clear();
            webDriver.FindElement(locator).SendKeys(text);
        }

        public static void EnterText(IWebElement element, int value)
        {
            element.Clear();
            element.SendKeys(value.ToString());
        }

        public static void EnterTextWithoutClearing(By locator, String text)
        {
            webDriver.FindElement(locator).SendKeys(text);
        }

        public static void SelectFromDropDownByValue(IWebElement element, String value)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);
        }

        //km
        public static void CheckDropDownOptions(IList<IWebElement> list, String dropdownList)
        {
            String[] allText = new String[list.Count];

            List<string> s = new List<string>(dropdownList.Split(new string[] { "," }, StringSplitOptions.None));

            int i = 0;
            foreach (IWebElement element in list)
            {
                allText[i++] = element.Text;
                List<string> ss = new List<string>(element.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None));
                for (int j = 0; j <= ss.Count - 1; j++)
                {
                    if (s[j] != ss[j])
                    {
                        throw new Exception("Dropdown list not returning expected Results");
                    }
                }
            }
        }

        public static void SelectFromDropDownList(IList<IWebElement> list, String text, By locator)
        {
            String[] allText = new String[list.Count];

            int i = 0;
            foreach (IWebElement element in list)
            {
                allText[i++] = element.Text;
                List<string> ss = new List<string>(element.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None));
                for (int j = 0; j <= ss.Count - 1; j++)
                {
                    if (text == ss[j])
                    {
                        var divElement = webDriver.FindElement(locator);
                        divElement.FindElement(By.XPath(".//li"));
                        divElement.FindElements(By.XPath(".//li")).ElementAt(j).Click();
                        Thread.Sleep(1000);
                    }
                }
            }
        }


        public static void SelectFromDropDownByText(IWebElement element, String text)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(text);
        }

        public static void SelectCheckBox(IWebElement element)
        {
            if(element.Displayed && !element.Selected)
            {
                element.Click();
            }
        }

        public static void SelectRadioOptionByForAttribute(By locator, String forAttribute)
        {
            IList<IWebElement> radios = webDriver.FindElements(locator);
            var radioToSelect = radios.FirstOrDefault(radio => radio.GetAttribute("for") == forAttribute);

            if (radioToSelect != null)
                ClickElement(radioToSelect);
        }
    }
}