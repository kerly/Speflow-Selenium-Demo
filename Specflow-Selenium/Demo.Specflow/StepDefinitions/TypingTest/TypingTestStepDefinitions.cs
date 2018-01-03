using Demo.Selenium.PageObjectModel.Generic;
using Demo.Selenium.PageObjectModel.TypingTest;
using Demo.Specflow.Exceptions.TypingTest;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;
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
        
        [Then(@"my typing speed should be greater than ""(\d+)"" WPM with ""(\d+)""\% accuracy")]
        public void ThenMyScoreShouldBeGreaterThan(int minimumWPM, int minimumAccuracy)
        {
            // Get the Selenium driver from the context
            IWebDriver webDriver = ScenarioContext.Current.Get<IWebDriver>();

            // Create an instance of the typing test page
            TypingTestResultsPage typingTestResultsPage = new TypingTestResultsPage(webDriver);

            // Verify the score is maxed out
            // Get the results from the page
            string typingSpeed = typingTestResultsPage.FindWebElement(TypingTestResultsPage.WebElementDivSpeed, TimeSpan.FromSeconds(5)).Text;
            string typingAccuracy = typingTestResultsPage.FindWebElement(TypingTestResultsPage.WebElementDivAccuracy, TimeSpan.FromSeconds(5)).Text;

            // Extract the result values
            float typingSpeedValue = float.Parse(Regex.Match(typingSpeed, @"(\d+(\.\d+)?) WPM").Groups[1].Value);
            float typingAccuracyValue = float.Parse(Regex.Match(typingAccuracy, @"(\d+(\.\d+)?) \%").Groups[1].Value);

            // Verify the typing speed and typing accuracy are sufficient
            if(typingSpeedValue < minimumWPM)
            {
                throw new InsufficientTypingSpeedException(minimumWPM, typingSpeedValue);
            }
            if(typingAccuracyValue < minimumAccuracy)
            {
                throw new InsufficientTypingAccuracyException(minimumAccuracy, typingAccuracyValue);
            }
        }
    }
}
