Feature: Bookmarks

Background:
	Given I'm on the main page
	And I go to the authorization page
	When I login
	Then I clear bookmarks

Scenario: Check bookmarks
	Given I click catalog
	And I choose 'Смартфоны' in catalog
	And I choose favorite goods
	And I click catalog
	And I choose 'Электронные книги' in catalog
	And I choose favorite goods
	And I click catalog
	And I choose 'Наушники' in catalog
	And I choose favorite goods
	When I go to bookmarks page
	Then The goods I added to favorite are right
	And I clear bookmarks