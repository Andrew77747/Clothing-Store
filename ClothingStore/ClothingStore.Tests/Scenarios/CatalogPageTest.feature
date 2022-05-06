Feature: CatalogPageTest

Scenario: Check all product cards
	Given I'm on the main page
	When I click catalog
	And I choose 'Смартфоны' in catalog
	And I switch count of cards to '45'
	And I unfold all cards
	Then I see that amount of cards is equal to value

Scenario: Compare goods
	Given I'm on the main page
	When I click catalog
	And I choose 'Смартфоны' in catalog
	And I clear comparing
	Then I see compare list is empty
	When I add one good to compare
	Then I see icon compare is active and i see delete icon from comparing
	And I see the good I added in side menu In comparing
	When I delete from comparing with delete button in cards
	Then I see icon compare is inactive and i don't see delete icon from comparing
	When I refresh page
	Then I see compare list is empty
	When I add one good to compare
	And I clear comparing
	Then I see icon compare is inactive and i don't see delete icon from comparing
	Then I see compare list is empty

	#When I add two goods to compare
	#Then I see the goods I added in side menu In comparing
	#When I click Go to compare button in card
	#Then I'm on the compare page and I see two added goods
	#When I go back to previos page
	#Then I see compare list is empty
	#When I add two goods to compare
	#And I click Go to compare button in comparing list
	#Then I'm on the compare page and I see two added goods