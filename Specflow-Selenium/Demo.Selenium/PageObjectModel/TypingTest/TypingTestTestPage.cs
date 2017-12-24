using Demo.Selenium.PageObjectModel.Generic;
using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace Demo.Selenium.PageObjectModel.TypingTest
{
    /// <summary>
    /// Typing test test page
    /// </summary>
    public class TypingTestTestPage : AWebPageObjectModel
    {
        /// <summary>
        /// Web URL property
        /// </summary>
        public override string URL { get { return "https://www.ratatype.com/typing-test/test/"; } }

        // Web Elements
        public static By WebElementButtonStartTypingNow = By.ClassName("submit");
        public static By WebElementDivTestParagraph = By.ClassName("mainTxt");
        public static By WebElementSpanTestWord = By.XPath(@".//span");
        public static By WebElementTextAreaTypingArea = By.XPath("//textarea[@autocomplete='off']");
        

        /// <summary>
        /// Web page constructor
        /// </summary>
        /// <param name="webDriver">IWebDriver</param>
        public TypingTestTestPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        /// <summary>
        /// Take the typing test
        /// </summary>
        public void TakeTypingTest()
        {
            // Get the test paragraph
            IWebElement testParagraph = WebDriver.FindElement(WebElementDivTestParagraph);

            // Get each word in the paragraph
            IReadOnlyCollection<IWebElement> testWords = testParagraph.FindElements(WebElementSpanTestWord);

            // Get the output area
            IWebElement typingArea = WebDriver.FindElement(WebElementTextAreaTypingArea);

            // Loop all words in the test words, typing each one into the output area
            foreach(IWebElement testWord in testWords)
            {
                if(String.IsNullOrWhiteSpace(testWord.Text))
                {
                    // Enter a blank space if the word is a space
                    typingArea.SendKeys(" ");
                }
                else
                {
                    // Type each character individually
                    foreach(char character in testWord.Text)
                    {
                        typingArea.SendKeys(character.ToString());
                    }
                }
            }
        }
    }
}
