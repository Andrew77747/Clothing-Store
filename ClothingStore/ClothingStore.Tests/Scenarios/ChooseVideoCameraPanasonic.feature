Feature: ChooseVideoCameraPanasonic

Background:
	Given I'm on the main page
	And I go to the authorization page
	Then I login

Scenario: Choose Panasonic video
	Given I click catalog
	When I choose 'Видеокамеры' in catalog
	And I click digital videocameras
	And I choose Panasonic
	And I choose sorting by price asc
	Then I see only Panasonic videocameras sorting by price asc