Feature: CatalogPageTest

Scenario: Check all product cards
	Given I'm on the main page
	When I click catalog
	And I choose 'Смартфоны' in catalog
	And I switch count of cards to '45'
	And I unfold all cards
	Then I see that amount of cards is equal to value