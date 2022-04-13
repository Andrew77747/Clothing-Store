Feature: Map

Scenario: Map zoom
	Given I'm on the main page
	When I choose 'Санкт-Петербург' city
	And I click 'Пункты выдачи' menu item
	And I click show map
	Then I zoom map