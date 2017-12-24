@web_based @chrome
Feature: MaxOutTypingTest
	Take a typing test and max out the score

Scenario: Max out the typing test
	Given I navigate to the typing test website
	When I take the typing test
	Then my score should be maxed out at "500" WPM
