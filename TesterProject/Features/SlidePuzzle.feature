#Feature: SlidePuzzle
#
#Scenario: Make a move
#	Given a game is started
#	And a user wants to move a tile to the "left"
#	And the tile to the "left" is empty
#	When the tile is moved to the "left"
#	Then the move is successed
#
#Scenario: Creating a possible game
#	Given a player wants to create a game
#	When the player gives a game size "9"
#	And the game size is legal
#	Then the game is created
#
#Scenario: Creating a none possible game
#	Given a player wants to create a game
#	When the player gives a game size "8"
#	And the game size is illegal
#	Then the game is not created
#
#Scenario: a game is completed
#	Given a game is created with a game size "9"
#	When the tiles is in nummerical order from smallest to biggest
#	And the position of the empty tile ís in the end
#	Then the game is completed
#
#Scenario: a game is running
#	Given a game is created with a game size "9"
#	When the tiles isn't in nummerical order from smallest to biggest
#	Then the game isn't completed
#	And the user can still make a move
#
#Scenario: displaying the game board
#	Given a game is created with a game size "9"
#	When there is "8" tiles with numbers inside
#	And the tiles with these numbers is 1 to "8"
#	Then the game is displayed to the player
#
#Scenarios: tiles inside of the board
#	Given a game is created with a game size "9"
#	When a user moves a tile to the "down"
#	And the position below the tile is inside the board
#	And there isn't any tile at the postion below the tile
#	Then the tile is moved down
