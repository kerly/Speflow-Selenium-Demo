using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Demo.SpecFlow.Hooks.WebBrowser
{
    /// <summary>
    /// SpecFlow hooks for the web browser
    /// </summary>
    [Binding]
    public class WebBrowserHooks
    {
        /// <summary>
        /// Initialize the web browser for the scenario starts
        /// </summary>
        [BeforeScenario("web_based", "chrome")]
        public static void InitializeWebBrowser()
        {
            // Create the web driver
            IWebDriver webDriver = new ChromeDriver();

            // Maximize the window
            webDriver.Manage().Window.Maximize();

            // Store the web driver in the ScenarioContext
            ScenarioContext.Current.Set(webDriver);
        }

        /// <summary>
        /// Tear down the web browser after the scenario finishes
        /// </summary>
        [AfterScenario("web_based")]
        public static void TearDownWebBrowser()
        {
            // Get the web driver from the ScenarioContext
            IWebDriver webDriver;
            if(ScenarioContext.Current.TryGetValue(out webDriver))
            {
                // Tear down the web driver
                webDriver.Quit();
            }
        }
    }
}
