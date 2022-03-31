Feature: Buying goods

Background: 
Given I'm on the main page
And I go to the authorization page
And I login
And I clean shopping cart

Scenario: Add good to shopping cart
	When I find 'Смартфон Apple iPhone 11 128 GB Чёрный'
	And I add good to shopping cart
	Then 'Смартфон Apple iPhone 11 128 GB Чёрный' is in shopping cart