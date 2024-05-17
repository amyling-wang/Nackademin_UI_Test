@Utbildningar
Feature: Utbildningar

Background: 
	Given I navigate to Nackademin
	When I click on Utbildningar in main menu section
@Smoke
Scenario: Verify main section with education cards
	Then I should see page with title Utbildningar
	Then I should see 15 cards on the page
	When I click on dropdown button for Sortera
	Then I choose option Utbildningsnamn in dropdown for Sortera
	And I verify all cards are sorted by education names

Scenario: Verify filter functionality
	Then I click on dropdown button Område and choose below mentoned options and verify
		| Option            |
		| Design            |
		| Elteknik & energi |
		| IT                |
		| Kommunikation     |
		| Samhällsbyggnad   |
		| Spel              |
		| Vård & hälsa      |
	Then I click on dropdown button Utbildningstyp and choose below mentoned options and verify
		| Option  |
		| Kurs    |
		| Program |
	Then I click on dropdown button Studieform and choose below mentoned options and verify
		| Option      |
		| Distans     |
		| Online      |
		| Platsbunden |
		| YH-flex     |
	Then I click on dropdown button Studieform and choose below mentoned options and verify
		| Option      |
		| Distans     |
		| Online      |
		| Platsbunden |
		| YH-flex     |

Scenario: Verify section for Frågor och Svar
	Then I should see section with title Frågor och svar
	And I should see information text for section Frågor och svar
	When I click on any question
	Then I should see related content under it

Scenario Outline: Verify news letter section
	Then I should see news letter section title on the page
	Then I enter <Email> in Din e-postadress field in section Få vårt nyhetsbrev
	When I click on button Prenumerera in section for Få vårt nyhetsbrev
	Then I should see a message contains <Message> in the section

Examples: 
	| Email                   | Message |
	| name.eftername.test.com | problem |
	| name.eftername@test.com | Tack    |

Scenario: Verify post email in sidfooter section on Home page
	Then I enter <Email> in Din e-postadress field in section site footer
	When I click on button Prenumerera in section for site footer
	Then I should see a message contains <Message> in the section

Examples: 
	| Email                   | Message |
	| name.eftername.test.com | problem |
	| name.eftername@test.com | Tack    |

Scenario: Verify sidfooter for Utbildningar page
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






	