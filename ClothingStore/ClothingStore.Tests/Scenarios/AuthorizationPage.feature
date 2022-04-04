Feature: AuthorizationPage

Scenario: Check Login and account
	Given I'm on the main page
	And I go to the authorization page
	When I login
	And I go to personal area
	Then I'm in my account