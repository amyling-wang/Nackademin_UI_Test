@Inspiration
Feature: Inspiration

Background: 
	Given I navigate to Nackademin
	When I click on Inspiration in main menu section

Scenario: Verify main section with inspiration cards
	Then I should see page with title test
	Then I should see 20 cards on the page by default
	When I click on button for Sortera
	Then I choose option Utbildningsnamn in dropdown for Sortera
	And I verify all cards are sorted by names