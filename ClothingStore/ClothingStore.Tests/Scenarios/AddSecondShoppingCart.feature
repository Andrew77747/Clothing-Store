Feature: AddSecondShoppingCart

Background:
	Given I'm on the main page
	And I go to the authorization page
	When I login
	Then I delete all added shopping carts
	#And I clear shopping cart with basic checkbox
	And I clean shopping cart

Scenario: Add second shopping cart
	Given I create new shopping cart 'My new shopping cart'
	When I choose basic shopping cart
	Then I see shopping cart I created
	When I choose added shopping cart in basket sticker
	Then I see added shopping is active
	When I choose basic shopping cart in basket sticker
	Then I see basic shopping is active
	When I click catalog
	And I choose 'Смартфоны' in catalog
	And I click buy button in cart on catalog page
	And I click continue buying in modal
	And I go to shopping cart
	Then I see good I added in basic shopping cart
	When I clear basic shopping cart
	And I switch on second shopping cart
	And I click catalog
	And I choose 'Смартфоны' in catalog
	And I click buy button in cart on catalog page
	And I click continue buying in modal
	And I go to shopping cart
	Then I see good I added in second shopping cart
	When I delete second shopping cart
	Then I see only one basic shopping cart
	And I clean shopping cart

Scenario: Replace good to another shopping cart and postpone buying
	Given I create new shopping cart 'My new shopping cart'
	When I choose basic shopping cart
	And I click catalog
	And I choose 'Смартфоны' in catalog
	And I click buy button in cart on catalog page
	And I click continue buying in modal
	And I go to shopping cart
	And I click good checkbox
	And I replace good to new added shopping cart with replace button
	Then I see good in new added shopping cart
	And I see right counter
	When I choose basic shopping cart
	Then I don't see good I replace in basic shopping cart
	When I switch on second shopping cart
	And I replace good to basic shopping cart with replace icon
	Then I see good in basic shopping cart
	And I see right counter again
	When I switch on second shopping cart
	Then I don't see good I replace in new added shopping cart
	When I choose basic shopping cart
	And I click good checkbox
	And I click buy later button
	Then I see recover button and I don't see postpone icon
	When I click recover button
	Then I see postpone icon and I don't see recover button
	When I click postpone icon
	Then I see recover button and I don't see postpone icon
	And I delete all added shopping carts
	And I clean shopping cart

Scenario: Replace good to another shopping cart with creating one in process
	Given I click catalog
	When I choose 'Смартфоны' in catalog
	And I click buy button in cart on catalog page
	And I click continue buying in modal
	And I go to shopping cart
	And I click good checkbox
	And I click replace button
	And I create new shopping 'My new shopping cart' cart and replace good
	Then I see good in new added shopping cart
	And I see right counter
	When I choose basic shopping cart
	Then I don't see good I replace in basic shopping cart
