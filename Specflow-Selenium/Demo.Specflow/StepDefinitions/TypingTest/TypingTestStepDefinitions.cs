using Demo.Selenium.PageObjectModel.Generic;
using Demo.Selenium.PageObjectModel.TypingTest;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Demo.SpecFlow.StepDefinitions.TypingTest
{
    [Binding]
    public class MaxOutTypingTestSteps
    {
        [Given(@"I navigate to the typing test website")]
        public void GivenINavigateToTheTypingTestWebsite()
        {
            // Get the Selenium driver from the context
            IWebDriver webDriver = ScenarioContext.Current.Get<IWebDriver>();

            // Navigate to the website
            IWebPageObjectModel typingTestHomePage = new TypingTestHomePage(webDriver);
            typingTestHomePage.GoToPage();
        }
        
        [Given(@"I begin taking a typing test")]
        public void GivenIBeginTakingATypingTest()
        {
            // Get the Selenium driver from the context
            IWebDriver webDriver = ScenarioContext.Current.Get<IWebDriver>();

            // Create an instance of the typing test home page
            TypingTestHomePage typingTestHomePage = new TypingTestHomePage(webDriver);

            // Click the link to navigate to the typing test tab
            typingTestHomePage.FindWebElement(TypingTestHomePage.WebElementLinkTypingTest, TimeSpan.FromSeconds(15)).Click();

            // Click the button to go to the typing test page
            typingTestHomePage.FindWebElement(TypingTestHomePage.WebElementLinkTakeTypingTest, TimeSpan.FromSeconds(15)).Click();
        }
        
        [When(@"I take the typing test")]
        public void WhenITakeTheTypingTest()
        {
            // Get the Selenium driver from the context
            IWebDriver webDriver = ScenarioContext.Current.Get<IWebDriver>();
            TypingTestTestPage typingTestTestPage = new TypingTestTestPage(webDriver);

            // Click the button to start the typing test
            typingTestTestPage.BeginTypingTest();

            // Take the typing test
            typingTestTestPage.TakeTypingTest();
        }
        
        [Then(@"my score should be maxed out at ""(.*)"" WPM")]
        public void ThenMyScoreShouldBeMaxedOutAtWPM(int maxWPM)
        {
            // Get the Selenium driver from the context
            IWebDriver webDriver = ScenarioContext.Current.Get<IWebDriver>();

            // Verify the score is maxed out
        }
    }
}
