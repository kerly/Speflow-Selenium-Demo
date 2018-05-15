@web_based @chrome
Feature: TypingTestWorldRecord
	Take a typing test at world record speed and accuracy

Scenario: Typing Test world record
	Given I navigate to the typing test website
	When I take the typing test
	Then my typing speed should be greater than "450" WPM with "100"% accuracy
