@web_based @chrome
Feature: MaxOutTypingTest
	Take a typing test and max out the score

Scenario: Max out the typing test
	Given I navigate to the typing test website
	When I take the typing test
	Then my typing speed should be greater than "400" WPM with "100"% accuracy
