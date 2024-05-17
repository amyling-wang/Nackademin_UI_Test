@Foretag
Feature: FörFöretag

Background: 
	Given I navigate to Nackademin
	When I click on För företag in main menu section

Scenario: Verify main image section and on För företag page
	Then I should see image with text 'För företag'

Scenario: Verify section for Närheten till arbetslivet är allt
	Then I should see section with title Närheten till arbetslivet är allt
	And I should see image for section Närheten till arbetslivet är allt

Scenario: Verify sections with link to Utforska våra event and samarbeta med oss
	Then I Verify below sections on the page
		| Section title                  | Section category  | Section link        |
		| Upptäck framtidens möjligheter | Event             | Utforska våra event |
		| Bygg framgång tillsammans      | Samarbeta med oss | Läs mer             |

Scenario: Verify section for Samarbetspartners
	Then I should see section with title Samarbetspartners
	Then I should see some company logo in the section
	And I veriy Visa fler button is shown in the section

Scenario: Verify Relaterade artiklar on För företags page
	Then I should see 3 articles by default under section with title Relaterade artiklar
	When I click on the button Visa fler artiklar
	Then I should be navigated to Inspiration

Scenario Outline: Verify section with field
	Then I should see section with title Nyfiken på våra företagsutbildningar?
	Then I fill <Name> in Namn field
	And I fill <Company> in Företag field
	Then I fill <Email> in E-postadress field
	And I fill <Message> in Meddelande/Utbildningsbehov field
	When I click on button Skicka
	Then I should see a message contains <Output> in the section

Examples: 
	 | Name  | Company | Email                   | Message   | Output  |
	 | Adam  | Flexera | name.eftername.test.com | Hej 123 * | problem |
	# | Kalle | Flexera | name.eftername@test.com | Hej 123 & | Tack    |

Scenario: Verify sidfooter for För företag page
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

#Scenario: Verify post email in sidfooter section on Home page
#	Then I enter <Email> in Din e-postadress field in section site footer
#	When I click on button Prenumerera in section for site footer
#	Then I should see a message contains <Message> in the section
#
#Examples: 
#	| Email                   | Message |
#	| name.eftername.test.com | problem |
#	| name.eftername@test.com | Tack    |
