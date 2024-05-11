Feature: Utbildningar

Background: 
	Given I navigate to Nackademin
	When I click on Utbildningar in main menu section
@ignore
Scenario: Verify main section with education cards
	Then I should see page with title Utbildningar
	Then I should see 15 cards on the page
	When I click on dropdown button for Sortera
	Then I choose option Utbildningsnamn in dropdown for Sortera
	And I verify all cards are sorted by education names
@ignore
Scenario: Verify filter functionality
	When I click on dropdown button Område and choose below mentoned options and verify
		| Option            |
		| Design            |
		| Elteknik & energi |
		| IT                |
		| Kommunikation     |
		| Samhällsbyggnad   |
		| Spel              |
		| Vård & hälsa      |





	