Feature: SlidePuzzle

Scenario: Make a move
	Given a game is started
	And a user wants to move a square to the "left"
	And the square to the "left" is empty
	When the square is moved to the "left"
	Then the move is successed

Scenario: Creating a possible game
	Given a player wants to create a game
	When the player gives a game size "9"
	And it is possible to square the game size
	Then the game is created

Scenario: Creating a none possible game
	Given a player wants to create a game
	When the player gives a game size "8"
	And the game size is not squared
	Then the game is not created
	And the player gets an error message

Scenario: a game is completed
	Given a game is created with a size "9"
	And the game size is valid
	When the tiles is in nummerical order from smallest to biggest
	And the empty tile is the last position
	Then the game is completed

Scenario: a game is running
	Given a game is created with a size "9"
	And the game size is valid
	When the tiles isn't in nummerical order
	Then the game isn't completed
	And the player can make a move the empty tile

Scenario: displaying the game board
	Given a game is created with a size "9"
	And the game size is valid
	Then every tile is uniq
	And the value of the tiles is 1 to "9"-1
	And there is 1 tile that is empty
	Then the game is displayed to the player


inden or rammer
ikke oven på brik
kun ryk horisontalt eller verticalt

ligesom i cpp