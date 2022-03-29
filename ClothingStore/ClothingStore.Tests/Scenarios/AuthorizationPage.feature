Feature: AuthorizationPage

Scenario: Check Login
	Given I'm on the main page
	And I go to the authorization page
	When I login
	Then I'm in my account