using System;
using System.Diagnostics;
using System.IO;
using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.FindACourse.Project.Framework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
//using OpenQA.Selenium.PhantomJS;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using OWASPZAPDotNetAPI;
using System.Configuration;
using System.Collections.Specialized;
using OpenQA.Selenium.Remote;


namespace ESFA.UI.Specflow.Framework.Project.Tests.TestSupport
{
    [Binding]
    public class BaseTest
    {
        protected static IWebDriver webDriver;
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private static string screenshotPath;
        protected static int counter;
        protected static int counter2;
        public static ClientApi Zap;
        public static bool zapTest = false;
        protected static string reportLocation;

        [BeforeTestRun(Order =1)]
        public static void InitializeReport(object sender, EventArgs e)
        {
            //Create extent report
            string reportPath = "\\Project\\Reports\\";
            reportLocation = FileSystemHelper.CreateFilePath(reportPath);
            var htmlReporter = new ExtentHtmlReporter(reportLocation);
            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.Configuration().ReportName = reportLocation;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Test Environment", Configurator.GetConfiguratorInstance().GetBaseUrl());
            extent.AddSystemInfo("Test Configuration", Configurator.GetConfiguratorInstance().GetBrowser());
        }


        [AfterTestRun]
        public static void TearDown()
        {
            try
            {
                TakeScreenshotOnFailure();
            }
            finally
            {
                if (zapTest == true)
                {
                    //create OWASP Report
                    string reportPath = "\\Project\\OWASPReports\\";
                    reportLocation = FileSystemHelper.CreateFilePath(reportPath);
                    
                    Zap.Dispose();
                    WriteZapHtmlReport(reportLocation + "_PassiveScanReport.html", Zap.core.htmlreport());
                }
                webDriver.Quit();
                extent.Flush();
            }
        }


        [BeforeTestRun(Order = 2)]
        public static void SetUp()
        {
            String browser = Configurator.GetConfiguratorInstance().GetBrowser();
            switch (browser)
            {
                case "debug":
                    webDriver = new ChromeDriver();
                    webDriver.Manage().Window.Maximize();
                    break;

                case "win10chrome":
                    BrowserstackConfig();
                    break;

                case "win10edge":
                    BrowserstackConfig();
                    break;

                case "win10firefox":
                    BrowserstackConfig();
                    break;

                case "win10IE":
                    BrowserstackConfig();
                    break;

                case "osxECsafari":
                    BrowserstackConfig();
                    break;

                case "osxHSsafari":
                    BrowserstackConfig();
                    break;

                case "osxHsafari":
                    BrowserstackConfig();
                    break;

                case "osxHSchrome":
                    BrowserstackConfig();
                    break;

                case "osxHSfirefox":
                    BrowserstackConfig();
                    break;

                case "iOSchrome":
                    BrowserstackConfigMob();
                    break;

                case "iOSfirefox":
                    BrowserstackConfigMob();
                    break;

                case "iOSsafari":
                    BrowserstackConfigMob();
                    break;

                case "androidchrome":
                    BrowserstackConfigMob();
                    break;

                case "androidnative":
                    BrowserstackConfigMob();
                    break;

                //case "phantomjs":
                //    webDriver = new PhantomJSDriver();
                //    break;

                case "firefox":
                    webDriver = new FirefoxDriver();
                    webDriver.Manage().Window.Maximize();
                    break;

                case "ie":
                    webDriver = new InternetExplorerDriver();
                    webDriver.Manage().Window.Maximize();
                    break;

                case "zapProxyChrome":
                    InitialiseZapProxyChrome();
                    break;

                default:
                    throw new Exception("Driver name does not match OR this framework does not support the webDriver specified");
            }

            //webDriver.Manage().Window.Maximize();
            //webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //webDriver.Manage().Cookies.DeleteAllCookies();
            //String currentWindow = webDriver.CurrentWindowHandle;
            //webDriver.SwitchTo().Window(currentWindow);

            PageInteractionHelper.SetDriver(webDriver);

        }


        [BeforeFeature]
        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
            counter++;
            counter2++;
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            if (counter / counter2 == 5)
            {
                scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            counter2++;
            }
            counter++;
        }


        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }


        [BeforeStep]
        public void BeforeStep()
        {
            //TODO: implement logic that has to run before executing each step
        }


        [AfterStep]
        public static void InsertReportingSteps(object sender, EventArgs e)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "But")
                    scenario.CreateNode<But>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail((ScenarioContext.Current.TestError.Message) 
                                                                                            + (ScenarioContext.Current.TestError.StackTrace));
                    TakeScreenshotOnFailure();
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioStepContext.Current.StepInfo.Text).AddScreenCaptureFromPath(screenshotPath);
                }
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "But")
                    scenario.CreateNode<But>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
            }

            if (ScenarioContext.Current.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            }
        }

        public static void TakeScreenshotOnFailure()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                try
                {
                    DateTime dateTime = DateTime.Now;
                    String featureTitle = FeatureContext.Current.FeatureInfo.Title;
                    String scenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;
                    String failureImageName = dateTime.ToString("HH-mm-ss")
                        + "_"
                        + scenarioTitle
                        + ".png";
                    String screenshotsDirectory = AppDomain.CurrentDomain.BaseDirectory
                        + "../../"
                        + "\\Project\\Screenshots\\"
                        + dateTime.ToString("dd-MM-yyyy")
                        + "\\";
                    if (!Directory.Exists(screenshotsDirectory))
                    {
                        Directory.CreateDirectory(screenshotsDirectory);
                    }

                    ITakesScreenshot screenshotHandler = webDriver as ITakesScreenshot;
                    Screenshot screenshot = screenshotHandler.GetScreenshot();
                    screenshotPath = Path.Combine(screenshotsDirectory, failureImageName);
                    screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
                    Console.WriteLine(scenarioTitle
                        + " -- Scenario failed and the screenshot is available at -- "
                        + screenshotPath);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Exception occurred while taking screenshot - " + exception);
                }
            }
        }

        private static void InitialiseZapProxyChrome()
        {
            //connect to Zap service
            Zap = new ClientApi("localhost", 8095, null);
          

            //conffigure proxy
            const string PROXY = "localhost:8095";
            var chromeOptions = new ChromeOptions();
            var proxy = new Proxy();
            proxy.HttpProxy = PROXY;
            proxy.SslProxy = PROXY;
            proxy.FtpProxy = PROXY;
            proxy.IsAutoDetect = false;
            chromeOptions.Proxy = proxy;
            chromeOptions.AddArgument("ignore-certificate-errors");
            chromeOptions.AddArgument("start-maximized");
            chromeOptions.AddArguments("disable-infobars");
            zapTest = true;

            webDriver = new ChromeDriver(chromeOptions);
        }

        public static void WriteZapHtmlReport(string path, byte[] bytes)
        {
            File.WriteAllBytes(path, bytes);
        }

        public static void BrowserstackConfig()
        {
            DesiredCapabilities capability = new DesiredCapabilities();
            capability.SetCapability("browserName", ConfigurationManager.AppSettings["browser"]);
            capability.SetCapability("browser_version", ConfigurationManager.AppSettings["browser_version"]);
            capability.SetCapability("name", ConfigurationManager.AppSettings["name"]);
            capability.SetCapability("os", ConfigurationManager.AppSettings["os"]);
            capability.SetCapability("os_version", ConfigurationManager.AppSettings["os_version"]);
            capability.SetCapability("browserstack.user", ConfigurationManager.AppSettings["user"]);
            capability.SetCapability("browserstack.key", ConfigurationManager.AppSettings["key"]);

            NameValueCollection caps = ConfigurationManager.GetSection("capabilities/" + "parallel") as NameValueCollection;
            foreach (string key in caps.AllKeys)
            {
                capability.SetCapability(key, caps[key]);
            }
            webDriver = new RemoteWebDriver(new Uri("http://" + ConfigurationManager.AppSettings.Get("server") + "/wd/hub/"), capability);
        }

        public static void BrowserstackConfigMob()
        {
            DesiredCapabilities capability = new DesiredCapabilities();
            capability.SetCapability("browserName", ConfigurationManager.AppSettings["browserName"]);
            capability.SetCapability("device", ConfigurationManager.AppSettings["device"]);
            capability.SetCapability("realMobile", ConfigurationManager.AppSettings["realMobile"]);
            capability.SetCapability("name", ConfigurationManager.AppSettings["name"]);
            capability.SetCapability("os_version", ConfigurationManager.AppSettings["os_version"]);

            //String username = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
            //if (username == null)
            //{
            //    username = ConfigurationManager.AppSettings.Get("user");
            //}

            //String accesskey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");
            //if (accesskey == null)
            //{
            //    accesskey = ConfigurationManager.AppSettings.Get("key");
            //}

            //capability.SetCapability("browserstack.user", username);
            //capability.SetCapability("browserstack.key", accesskey);

            capability.SetCapability("browserstack.user", ConfigurationManager.AppSettings["user"]);
            capability.SetCapability("browserstack.key", ConfigurationManager.AppSettings["key"]);

            NameValueCollection caps = ConfigurationManager.GetSection("capabilities/" + "parallel") as NameValueCollection;
            foreach (string key in caps.AllKeys)
            {
                capability.SetCapability(key, caps[key]);
            }
            webDriver = new RemoteWebDriver(new Uri("http://" + ConfigurationManager.AppSettings.Get("server") + "/wd/hub/"), capability);
        }

    }
}