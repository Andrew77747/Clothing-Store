Feature: HelpAndSupport

Background:
	Given I'm on the main page
	And I go to the authorization page
	When I login

Scenario: Message to support
	Given I click 'Помощь' menu item
	When I click 'Оформление заказа'
	And I select dropdown Theme 'Покупка на физическое лицо'
	Then I see hint message
	When I type message
	And I upload picture
	Then The picture is uploaded successfully