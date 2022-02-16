Feature: Calculator

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: succes login
	Given a user with a username
	And a user with a password
	When the user wants to login
	And the username and password is correct
	Then the user is login succesful