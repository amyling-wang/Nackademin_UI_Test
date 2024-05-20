@Antagning
Feature: Antagning
Background: 
	Given I navigate to Nackademin
	When I click on Antagning in main menu section

Scenario: Verify main image section on Antagning
	Then I should see image with text 'Välkommen till Nackademins antagning!'
	When I click on the button Till utbildningarna
	Then I should be navigated to Utbildningar

Scenario: Verify sections under main
	Then I verify below mentiond cards and related links for them on Antagning page
		| Cart name              |
		| Hur ansöker jag?       |
		| Urval & antagningsprov |
		| Inför din studiestart  |
	Then I should see section with title Fler frågor?

@ignore
Scenario: Verify sidfooter for Home page
	When I click on link navigates to Home page in page footer
	Then I verify below mentioned links in site footer section
		| Link name       | Landing page  |
		| Utbildningar    | Utbildningar  |
		| Antagning       | Antagning     |
		| För företag     | För företag   |
		| Inspiration     | Inspiration   |
		| Om Nackademin   | Om Nackademin |
		| Pressrum        | Pressrum      |
		| Kontakta oss    | Kontakta oss  |
		| Medarbetare     | Medarbetare   |
		| Frågor och svar | FAQ           |

Scenario: Verify post email in sidfooter section on Home page
	Then I enter <Email> in Din e-postadress field in section site footer
	When I click on button Prenumerera in section for site footer
	Then I should see a message contains <Message> in the section

Examples: 
	| Email                   | Message |
	| name.eftername.test.com | problem |
	| name.eftername@test.com | Tack    |