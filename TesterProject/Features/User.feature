@User
Feature: User

Scenario: Get users
	Given I select all valid users
	When I click the see all user button
	Then I get all the users returned
	
Scenario: Get user
	Given I select a valid user
	When I click the get information about the user button
	Then I get the user information returned
	
Scenario: Create user
	Given I am a new user
	And I submit valid data
	When I click the create user button
	Then The user is successfully created
	
Scenario: Update user
	Given I am an existing user
	And I submit valid data
	When I click the update user button
	Then The user is successfully updated