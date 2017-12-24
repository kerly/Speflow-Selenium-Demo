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

        [Given(@"I log into the typing test website as ""(.*)"", ""(.*)""")]
        public void GivenILogIntoTheTypingTestWebsite(string userName, string password)
        {
            // Get the Selenium driver from the context
            IWebDriver webDriver = ScenarioContext.Current.Get<IWebDriver>();

            // Create an instance of the typing test pages
            TypingTestHomePage typingTestHomePage = new TypingTestHomePage(webDriver);
            TypingTestLoginPage typingTestLoginPage = new TypingTestLoginPage(webDriver);

            // Navigate to the login page
            typingTestHomePage.FindWebElement(TypingTestHomePage.WebElementLinkLogin, TimeSpan.FromSeconds(5)).Click();

            // Login
            typingTestLoginPage.Login(userName, password);
        }

        [When(@"I take the typing test")]
        public void WhenITakeTheTypingTest()
        {
            // Get the Selenium driver from the context
            IWebDriver webDriver = ScenarioContext.Current.Get<IWebDriver>();

            // Create an instance of the typing test pages
            TypingTestHomePage typingTestHomePage = new TypingTestHomePage(webDriver);
            TypingTestTestPage typingTestTestPage = new TypingTestTestPage(webDriver);                        

            // Click the links that start the typing test
            typingTestHomePage.FindWebElement(TypingTestHomePage.WebElementLinkTypingTest, TimeSpan.FromSeconds(5)).Click();
            typingTestHomePage.FindWebElement(TypingTestHomePage.WebElementLinkTakeTypingTest, TimeSpan.FromSeconds(5)).Click();
            typingTestTestPage.FindWebElement(TypingTestTestPage.WebElementButtonStartTypingNow, TimeSpan.FromSeconds(5)).Click();

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
