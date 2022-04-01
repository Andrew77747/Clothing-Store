Feature: ChooseVideoCameraPanasonic

Background:
	Given I'm on the main page
	And I go to the authorization page
	And I login

Scenario: Choose Panasonic video
	When I click catalog
	And I choose 'Видеокамеры' in catalog
	And I click digital videocameras
	And I choose Panasonic
	And I choose sorting by price asc
	Then I see only Panasonic videocameras sorting by price asc