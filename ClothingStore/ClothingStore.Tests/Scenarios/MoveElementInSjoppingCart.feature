Feature: MoveElementInStoppingCart

Background:
	Given I'm on the main page
	And I go to the authorization page
	When I login
	Then I clean shopping cart

Scenario: Move element
	Given I click catalog
	When I choose 'Смартфоны' in catalog
	And I click buy button in catalog
	And I click continue buying in modal
	And I click buy button in catalog
	And I click continue buying in modal
	And I go to shopping cart
	And I add current location of cards 
	Then I see two cards in shopping cart
	When I move the first card below
	Then I see cards changed places
	When I add current location of cards
	And I move the second card higher
	Then I see cards changed places