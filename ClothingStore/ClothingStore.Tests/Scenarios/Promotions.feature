Feature: Promotions

Background:
	Given I'm on the main page

Scenario: Check promotions amount
	Given I click promotions button
	When I switch paginator on promotion pages
	Then Amount of prmotions is correct