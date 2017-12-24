using Demo.Selenium.PageObjectModel.Generic;
using OpenQA.Selenium;

namespace Demo.Selenium.PageObjectModel.TypingTest
{
    /// <summary>
    /// Web page object model for the Typing Test Home Page
    /// </summary>
    public class TypingTestHomePage : AWebPageObjectModel
    {
        /// <summary>
        /// Web URL property
        /// </summary>
        public override string URL { get { return "http://www.ratatype.com"; } }

        // Web Elements
        public static By WebElementLinkLogin = By.PartialLinkText("Log In");
        public static By WebElementLinkTypingTest = By.XPath(@"//a[contains(@href, 'typing-test')]");
        public static By WebElementLinkTakeTypingTest = By.ClassName("submit");

        /// <summary>
        /// Web page constructor
        /// </summary>
        /// <param name="webDriver">Instance of an IWebDriver</param>
        public TypingTestHomePage(IWebDriver webDriver) : base(webDriver)
        {
        }
    }
}
