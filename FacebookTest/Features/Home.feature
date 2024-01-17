Feature: Home

Background: 
	Given I sign in to Facebook
	When I click on Home tab

Scenario: Verify side menu and create story function
	Then I verify below mentioned side menus are shown on the page
		| Side meny    |
		| Find friends |
		| Welcome      |
		| Saved        |
		| Memories     |
		| Groups       |
		| Video        |
		| Marketplace  |
		| Feeds        |
		| Events       |
		| Ads Manager  |
	Then I delete the story if present	
	And I create a story
	Then I delete the story if present
