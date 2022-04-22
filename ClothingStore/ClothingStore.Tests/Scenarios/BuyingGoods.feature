Feature: Buying goods

Background:
	Given I'm on the main page
	And I go to the authorization page
	When I login
	Then I clean shopping cart

Scenario: Add good to shopping cart
	Given I find 'Смартфон Apple iPhone 13 mini 128GB Тёмная ночь'
	When I add good to shopping cart
	Then 'Смартфон Apple iPhone 13 mini 128GB Тёмная ночь' is in shopping cart
	And I clean shopping cart

Scenario: Add goods to shopping cart and make order
	Given I click catalog
	When I choose 'Смартфоны' in catalog
	And I click title product card with buy button
	And I click buy button on good page
	And I click continue buying in modal
	And I click catalog
	And I choose 'Фотоаппараты' in catalog
	And I click digital SLR cameras
	And I click title product card with buy button
	And I click buy button on good page
	And I click continue buying in modal
	And I click catalog
	And I choose 'Телевизоры' in catalog
	And I click title product card with buy button
	And I click buy button on good page
	And I click continue buying in modal
	And I click catalog
	And I choose 'Умные колонки' in catalog
	And I click title product card with buy button
	And I click buy button on good page
	And I click continue buying in modal
	And I click catalog
	And I hover on 'Игры, софт и развлечения' in side catalog menu
	And I choose 'Консоли Xbox Series' in catalog
	And I click title product card with buy button
	And I click buy button on good page
	And I click continue buying in modal
	And I go to shopping cart
	Then I check that all goods are added
	When I choose delivery, payment method and click submit
	Then I check user data
	And I check order data
	And I clean shopping cart