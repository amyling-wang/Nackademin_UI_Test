Feature: Home

Background: 
	Given I sign in to Facebook
	When I click on Home tab

Scenario: Verify create story function
	Then I create a story
	Then I delete the story
