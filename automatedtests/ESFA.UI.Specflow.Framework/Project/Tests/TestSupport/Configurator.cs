using System;
using System.Configuration;

namespace ESFA.UI.Specflow.Framework.Project.Tests.TestSupport
{
    public class Configurator
    {
        private static Configurator configuratorInstance = null;

        private String browser;
        private String baseUrl;
        private String useBS;

        private Configurator()
        {
            browser = ConfigurationManager.AppSettings["Browser"];
            useBS = ConfigurationManager.AppSettings["useBS"];
            baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        }

        public static Configurator GetConfiguratorInstance()
        {
            if (configuratorInstance == null)
            {
                configuratorInstance = new Configurator();
            }
            return configuratorInstance;
        }

        public String GetBrowser()
        {
            return browser;
        }

        public String GetBaseUrl()
        {
            return baseUrl;
        }

        public String GetUseBS()
        {
            return useBS;
        }
    }
}