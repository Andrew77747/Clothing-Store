Feature: ViewedGoods

Background:
	Given I'm on the main page
	And I go to the authorization page
	When I login
	Then I clean viewed goods

Scenario: Viewed goods are shown correct
	Given I click catalog
	And I choose 'Мобильные телефоны' in catalog
	And I click title product card with buy button and add good name to list
	And I click catalog
	And I choose 'Электронные книги' in catalog
	And I click title product card with buy button and add good name to list
	And I click catalog
	And I choose 'Наушники' in catalog
	And I click title product card with buy button and add good name to list
	When I go to personal area
	And I go to viewed goods page
	Then The goods I added are right
	And I clean viewed goods