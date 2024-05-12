Feature: Home

Background: 
	Given I navigate to Nackademin
	
@Smoke
Scenario: Verify main image section on Home
	When I click on link navigates to Home page in page header
	Then I should see image with text 'Din framtid börjar här'
	When I click on the button Hitta utbildning
	Then I should be navigated to Utbildningar

Scenario: Verify Program, Kurser and För Företag section
	Then I verify below mentiond cards and related links for them on Home page
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
	Then I should be navigated to Inspiration
	
Scenario: Verify section for Frågor och Svar
	Then I should see section with title Frågor och svar
	And I should see information text for section Frågor och svar
	When I click on any question
	Then I should see related content under it

Scenario Outline: Verify news letter section
	Then I should see news letter section title on the page
	Then I enter <Email> in Din e-postadress field in section Få vårt nyhetsbrev
	When I click on button Prenumerera in section for Få vårt nyhetsbrev
	Then I should see the message contains <Message> in section Få vårt nyhetsbrev

Examples: 
	| Email                   | Message |
	| name.eftername.test.com | ogiltig |
	| name.eftername@test.com | Tack    |

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
	Then I should see the message contains <Message> in section site footer

Examples: 
	| Email                   | Message |
	| name.eftername.test.com | ogiltig |
	| name.eftername@test.com | Tack    |

Scenario: Verify Home Page meny section
	Then I click on button beside Utbildningar in meny section
	Then I verify below mentioned links in meny section under Utbildningar
		| Link name         | Landing page      |
		| Alla utbildningar | Utbildningar      |
		| Kurser            | Kurs              |
		| Program           | Program           |
		| Platsbunden       | Platsbunden       |
		| Distans           | Distans           |
		| Online            | Online            |
		| YH-flex           | YH-flex           |
		| Design            | Design            |
		| Elteknik & energi | Elteknik & energi |
		| IT                | IT                |
		| Kommunikation     | Kommunikation     |
		| Samhällsbyggnad   | Samhällsbyggnad   |
		| Spel              | Spel              |
		| Vård              | Vård & hälsa      |

		
