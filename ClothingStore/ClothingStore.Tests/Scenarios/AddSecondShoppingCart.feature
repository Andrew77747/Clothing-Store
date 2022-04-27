Feature: AddSecondShoppingCart

Background:
	Given I'm on the main page
	And I go to the authorization page
	When I login
	Then I delete all added shopping carts
	And I clean shopping cart

Scenario: Add second shopping cart
	Given I create new shopping cart 'My new shopping cart'
	When I choose basic shopping cart
	Then I see shopping cart I created
	When I click catalog
	And I choose 'Смартфоны' in catalog
	And I click buy button in cart on catalog page
	And I click continue buying in modal
	And I go to shopping cart
	#Then I see good I added in basic shopping cart
	#When I clear basic shopping cart
	#And I switch on second shopping cart
	#And I click catalog
	#And I choose 'Смартфоны' in catalog
	#And I click buy button in cart on catalog page
	#And I click continue buying in modal
	#And I go to shopping cart
	#Then I see good I added in second shopping cart //и при нажатии кнопки корзины, когда заранее была выбрана вторая корзина, мы переходим во вторую корзину
	#When I delete second shopping cart
	#Then I see only one basic shopping cart
	#And I clean shopping cart