Feature: Home

Background: 
	Given I navigate to Nackademin
	

Scenario: Verify image on Nackademin home
	When I click on page title Nackademin
	Then I should see a image with text 'Din fram tid börjar här'
	Then I click on the button Hitta utbildning
	And I should see page with title Utbildningar
	Then I close the child window
#	Then I should see below menys shown on the page
#		| Meny name    |
#		| Utbildningar |
#		| Antagning    |
#		| För företag  |
#		| Inspiration  |
#		| Om oss       |
#	Then I should see texten Yrkeshögskolan med utbildningar som leder till jobb shown on the page
#	And I should see below buttons shown on the page
#		| Button                   |
#		| Ansöka till våra program |
#		| Se vårt kursutbud        |
#		| Studera på distans       |
#	# Verify button with link?
#
#Scenario: Click on button on right side and verify
#	When I click on button to the right side
#	Then I should see texten Vägen till drömjobbet
#	Then I should see below buttons shown on the page
#		| Button                                           |
#		| Jag vill söka en IT-utbildning                   |
#		| Jag vill söka en spelutbildning                  |
#		| Jag vill söka en utbildning inom samhällsbyggnad |
#
#Scenario: Verify section Hittar rätt utbildning direct
#	Then I should see section Hitta rätt utbildning - direct! on Home page
#	Then I should see some text under section Hitta rätt utbildning - direct!
#	And I verify below mentioned tile in the section
#		| Tile name           |
#		| Samhällsbyggnad     |
#		| Design              |
#		| Elteknik och energi |
#		| IT                  |
#		| Kommunikation       |
#		| Vård                |
#		| Spel                |
#		| YH-Kurser           |
#		| Onlineutbildningar  |
#		| Distansutbildningar |
#
#Scenario: Verify section Aktuellt
#	Then I should see section Actuellt on Home pgae
#	Then I should see some text under section Aktuellt
#	And I verify below mentioned tile in the section
#		| Tile name                                                 |
#		| Ansökan är öppen för alla våra YH-utbildningar.           |
#		| Studera en online-utbildningar inom IT och kommunikation. |
#
#Scenario: Verify section För företag
#	Then I should see section Företag on Home page
#	Then I should see some text under section Företag
#	And I verify below mentioned tile in the section
#		| Tile name                             |
#		| Träffa studenter på Branschdagarna    |
#		| Ta emot LIA-praktikanter              |
#		| Samarbeta med oss                     |
#		| FöretagsNackademin - Vidareutbildning |
#
#Scenario: Verify section Inspiration
#	Then I should see section Inspiration on Home page
#	Then I should see some text under section Inspiration
#	And I verify below mentioned tile in the section
#		| Tile name                             |
#		| Nackademin satsar på flexibla studiemöjligheter med YH-flex platser för Java och IT-säkerhet |
#		| Omställningsstudiestödet öppnar upp för karriärväxling för Nackademins studenter             |
#		| Omställningsstudiestödet: En värdefull möjlighet för karriärbyte                             |
#		| Mer inspiration!                                                                             |
#
#Scenario: Verify section Ett enkelt val
#	Then I should see section Ett enkelt val on Home page
#	Then I should see some text under section Ett enkelt val
#	And I should see below mentioned information text and respective discription for them
#		| Text                            |
#		| 9 av 10 får jobb                |
#		| + 1000 arbetsgivare             |
#		| Utbildningar med praktik        |
#		| Pricksäkra utbildningslösningar |
#
#Scenario: Verify Vanliga frågor och svar
#	Then I should see text Vanliga frågor och svar on Home page
#	When I click on random items under Vanliga frågor och svar
#	Then I verify related text for the item
#
#Scenario: Verify alert for Fortfarande fundersam
#	Then I should see alert for Fortfarande fundersam?
#	And I should see below buttons shows in the alert
#		| Button                   |
#		| Utbildningar	och kurser |
