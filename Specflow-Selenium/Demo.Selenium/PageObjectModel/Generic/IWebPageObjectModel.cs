using OpenQA.Selenium;
using System;

namespace Demo.Selenium.PageObjectModel.Generic
{
    /// <summary>
    /// Page object model interface
    /// </summary>
    public interface IWebPageObjectModel
    {
        /// <summary>
        /// Web URL property
        /// </summary>
        string URL { get; }

        /// <summary>
        /// Go directly to the web page
        /// </summary>
        void GoToPage();

        /// <summary>
        /// Find a web element on the page
        /// </summary>
        /// <param name="elementLocator">Element locator</param>
        /// <param name="timeOut">Amount of time to wait for element</param>
        /// <returns>IWebElement</returns>
        IWebElement FindWebElement(By elementLocator, TimeSpan timeOut);
    }
}
