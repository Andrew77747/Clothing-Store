Feature: Buying goods

Background: 
Given I'm on the main page
And I go to the authorization page
When I login
Then I clean shopping cart

Scenario: Add good to shopping cart
	Given I find 'Смартфон Apple iPhone 11 128 GB Чёрный'
	When I add good to shopping cart
	Then 'Смартфон Apple iPhone 11 128 GB Чёрный' is in shopping cart