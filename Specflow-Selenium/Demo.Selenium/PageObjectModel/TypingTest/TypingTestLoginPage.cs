using Demo.Selenium.PageObjectModel.Generic;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace Demo.Selenium.PageObjectModel.TypingTest
{
    /// <summary>
    /// Typing test login page
    /// </summary>
    public class TypingTestLoginPage : AWebPageObjectModel
    {
        /// <summary>
        /// Web URL property
        /// </summary>
        public override string URL { get { return "https://www.ratatype.com/login/"; } }

        // Web Elements
        public static By WebElementInputEmail = By.Id("email");
        public static By WebElementInputPassword = By.Id("password");
        public static By WebElementButtonLogIn = By.ClassName("submit");

        /// <summary>
        /// Web page constructor
        /// </summary>
        /// <param name="webDriver">Instance of an IWebDriver</param>
        public TypingTestLoginPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        /// <summary>
        /// Log in to the account
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        public void Login(string userName, string password)
        {
            // Enter the data in the login fields
            FindWebElement(WebElementInputEmail, TimeSpan.FromSeconds(5)).SendKeys(userName);
            FindWebElement(WebElementInputPassword, TimeSpan.FromSeconds(5)).SendKeys(password);

            // Click the log in button
            FindWebElement(WebElementButtonLogIn, TimeSpan.FromSeconds(5)).Click();

            // Wait briefly for the account to log in
            Thread.Sleep(5000);
        }
    }
}
