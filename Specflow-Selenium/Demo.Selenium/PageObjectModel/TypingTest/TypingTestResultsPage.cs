using Demo.Selenium.PageObjectModel.Generic;
using OpenQA.Selenium;

namespace Demo.Selenium.PageObjectModel.TypingTest
{
    public class TypingTestResultsPage : AWebPageObjectModel
    {
        /// <summary>
        /// Web URL property
        /// </summary>
        public override string URL { get { return "http://www.ratatype.com/typing-test/test/complete/"; } }

        // Web Elements
        public static By WebElementDivSpeed = By.XPath("//div[@class= 'completeSpeed']/div[@class='completeResult']");
        public static By WebElementDivAccuracy = By.XPath(@"//div[@class= 'completeAccuracy']/div[@class='completeResult']");

        /// <summary>
        /// Web page constructor
        /// </summary>
        /// <param name="webDriver">Instance of an IWebDriver</param>
        public TypingTestResultsPage(IWebDriver webDriver) : base(webDriver)
        {
        }
    }
}
