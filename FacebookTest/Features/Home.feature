Feature: Home

Background: 
	Given I navigate to Nackademin
	

Scenario: Verify main image section on Home
	When I click on page title Nackademin
	Then I should see image with text 'Din framtid börjar här'
	When I click on the button Hitta utbildning
	Then I should see page with title Utbildningar

Scenario: Verify Program, Kurser and För Företag section
	Then I verify below mentiond cards and related links for them
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

Scenario: Verify Inspiration section on Home page
	Then I should see 3 articles by default under section with title Inspiration
	When I click on the button Visa fler artiklar
	Then I should see page with title Inspiration
	
Scenario: Verify section for Frågor och Svar
	Then I should see section with title Frågor och svar
	And I should see information text for section Frågor och svar
	When I click on any question
	Then I should see related content under it

Scenario Outline: Verify news letter section
	Then I should see section with title Få vårt nyhetsbrev
	Then I enter <Email> in Din e-postadress field in section Få vårt nyhetsbrev
	When I click on button Prenumerera in section for Få vårt nyhetsbrev
	Then I should see the message contains <Message> in section Få vårt nyhetsbrev

Examples: 
	| Email                   | Message |
	| name.eftername.test.com | ogiltig |
	| name.eftername@test.com | Tack    |

Scenario: Verify sidfooter for Home page
	Then I should see NACKADEMIN in sidfooter for Home page
	When I click on link Utbildningar in sidfooter section
	Then I should see page with title Utbildningar
	When I click on link Antagning in sidfooter section
	Then I should see page with title Antagning
	When I click on link För företag in sidfooter section
	Then I should see page with title För företag
	When I click on link Inspiration in sidfooter section
	Then I should see page with title Inspiration
	When I click on link Om Nackademin in sidfooter section
	Then I should see page with title Om Nackademin
	When I click on link Pressrum in sidfooter section
	Then I should see page with title Pressrum
	When I click on link Kontakta oss in sidfooter section
	Then I should see page with title Kontakta oss
	When I click on link Medarbetare in sidfooter section
	Then I should see page with title Medarbetare
	When I click on link Frågor och svar in sidfooter section
	Then I should see page with title FAQ

Scenario: Verify post email in sidfooter section on Home page
	Then I enter <Email> in Din e-postadress field in sidfooter section
	When I click on button Prenumerera in sidfooter section
	Then I should see the message contains <Message> in sidfooter section

Examples: 
	| Email                   | Message |
	| name.eftername.test.com | ogiltig |
	| name.eftername@test.com | Tack    |