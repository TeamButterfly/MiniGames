Feature: SlidePuzzle

Scenario: Make a move
	Given a game is started
	And a user wants to move a square to the "left"
	And the square to the "left" is empty
	When the square is moved to the "left"
	Then the move is successed