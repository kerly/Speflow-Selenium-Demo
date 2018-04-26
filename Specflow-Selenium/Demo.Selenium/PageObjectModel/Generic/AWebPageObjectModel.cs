using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Demo.Selenium.PageObjectModel.Generic
{
    /// <summary>
    /// Abstract definition for the page object model
    /// </summary>
    public abstract class AWebPageObjectModel : IWebPageObjectModel
    {
        // Properties
        /// <summary>
        /// Instance of an IWebDriver
        /// </summary>
        protected IWebDriver WebDriver;

        /// <summary>
        /// Web URL property
        /// </summary>
        public abstract string URL { get; }

        /// <summary>
        /// Web page object model constructor
        /// </summary>
        /// <param name="webDriver">Instance of an IWebDriver</param>
        public AWebPageObjectModel(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        /// <summary>
        /// Go directly to the web page using the configured URL
        /// </summary>
        public virtual void GoToPage()
        {
            WebDriver.Navigate().GoToUrl(URL);
        }

        /// <summary>
        /// Find a web element on the page
        /// </summary>
        /// <param name="elementLocator">Element locator</param>
        /// <param name="timeOut">Amount of time to wait for element</param>
        /// <returns>IWebElement</returns>
        public virtual IWebElement FindWebElement(By elementLocator, TimeSpan timeOut)
        {
            // Create the web driver wait
            WebDriverWait wait = new WebDriverWait(WebDriver, timeOut);

            // Wait for the element to become visible
            IWebElement result = wait.Until<IWebElement>(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));

            // Return the web element
            return result;
        }
    }
}
