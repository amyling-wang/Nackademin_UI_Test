Feature: Utbildningar

Background: 
	Given I navigate to Nackademin
	When I click on Utbildningar in main menu section

Scenario: Verify title text and description
	Then I should be navigated to Utbildningar
	Then I should see page with title Utbildningar

	