﻿Feature: Home

Background: 
	Given I navigate to Nackademin
	

Scenario: Verify main image section on Home
	When I click on page title Nackademin
	Then I should see image with text 'Din framtid börjar här'
	Then I click on the button Hitta utbildning
	And I should see page with title Utbildningar

Scenario: Verify Program, Kurser and För Företag section
	Then I verify below mentiond carts and related links for them
		| Cart name   |
		| Program     |
		| Kurser      |
		| För Företag |

Scenario: Verify sections with with link to Om oss, Antagning and Hitta drömjobbet
	Then I Verify below sections on the page
		| Section title                     | Section category      | Section link     |
		| 30 år nära arbetslivet            | NACKADEMIN            | Om oss           |
		| Starta din framtid hos Nackademin | ANTAGNING             | Antagning        |
		| Nå ditt drömjobb med Nackademin   | VÄGEN TILL DRÖMJOBBET | Hitta drömjobbet |