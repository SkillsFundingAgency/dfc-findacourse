using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ESFA.UI.Specflow.Framework.Project.Framework.Helpers
{
    public class FormCompletionHelper : PageInteractionHelper
    {
        private static string courseOption;
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
        //public static void GetDropDownOptions(IWebElement element, String value)
        //{
        //    List<IWebElement> selectList = webDriver.FindElements(By element);
        //    webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        //    IList<IWebElement> options = selectList.Options;
        //    var optionCount = selectList.Options.Count;
        //    for (int i = 0; i < optionCount; i++)
        //    {
        //        Console.WriteLine("Drop down option: " + selectList.Options[i]);
        //        selectList.SelectByIndex(i);
        //    }
        //}


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