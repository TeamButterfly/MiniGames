using System;
using System.Collections.Generic;


namespace TicTacToe
{
    public class Game
    {
        string isRunning = "";
        int currentUser = 0;
        static List<int> playerMoves = new List<int>();
        static List<int> computerMoves = new List<int>();
        int computerPos;
        int playerPos;
        bool quitGame = false;

        public void play()
        {
            while (quitGame == false) {
                string[,] board = createBoard();
                while (isRunning.Equals(""))
                {
                    //player's move and make it's move
                    playerPos = move(board);
                    while (playerMoves.Contains(playerPos) || computerMoves.Contains(playerPos))
                    {
                        Console.WriteLine("That position is already taken. Try again!");
                        printBoard(board);
                        playerPos = move(board);
                    }

                    insertMove(playerPos, board, currentUser);
                    printBoard(board);
                    playerMoves.Add(playerPos);
                    isRunning = isGameWon(board);
                    if (isRunning.Length > 0) {
                        break;
                    }
                    currentUser = switchUser(currentUser);

                    //computer's turn and make it's move
                    Random rand = new Random();
                    computerPos = rand.Next(1, 10);
                    while (playerMoves.Contains(computerPos) || computerMoves.Contains(computerPos))
                    {
                        computerPos = rand.Next(1, 10);
                    }
                    insertMove(computerPos, board, currentUser);
                    computerMoves.Add(computerPos);
                    printBoard(board);
                    isRunning = isGameWon(board);
                    if (isRunning.Length > 0)
                    {
                        break;
                    }
                    currentUser = switchUser(currentUser);
                }
                restartGame();
            }
        }

        private string[,] createBoard()
        {

            string[,] board = {
            {" ", "|", " ", "|", " "},
            {"-", "+", "-", "+", "-"},
            {" ", "|", " ", "|", " "},
            {"-", "+", "-", "+", "-"},
            {" ", "|", " ", "|", " "}
            };

            printBoard(board);
            return board;
        }

        private void printBoard(string[,] board)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }

        private int move(string[,] board)
        {
            Console.WriteLine("It is the player's turn." +
                "Please enter your placement (1-9):");
            // TODO : should add exception handling if the user inserts non-ints
            int x = Convert.ToInt32(Console.ReadLine());
            bool correctInput = true;

            while (correctInput)
            {
                if (x <= 0 || x > 9)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid move please try again.");
                    printBoard(board);
                    Console.WriteLine("Please enter your placement (1-9):");
                    x = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    correctInput = false;
                }

            }
            Console.Clear();
            return x;
        }

        private void insertMove(int pos, string[,] board, int currentUser)
        {
            string symbol = " ";

            if (currentUser.Equals(0))
            {
                symbol = "X";
            }

            else if (currentUser.Equals(1))
            {
                symbol = "O";
            }

            else
            {
                Console.WriteLine("Error");
                return;
            }

            switch (pos)
            {
                case 1:
                    board[0, 0] = symbol;
                    break;

                case 2:
                    board[0, 2] = symbol;
                    break;

                case 3:
                    board[0, 4] = symbol;
                    break;

                case 4:
                    board[2, 0] = symbol;
                    break;

                case 5:
                    board[2, 2] = symbol;
                    break;

                case 6:
                    board[2, 4] = symbol;
                    break;

                case 7:
                    board[4, 0] = symbol;
                    break;

                case 8:
                    board[4, 2] = symbol;
                    break;

                case 9:
                    board[4, 4] = symbol;
                    break;

                default:
                    break;
            }
            Console.Clear();
        }

        private int switchUser(int currentUser)
        {
            if (currentUser.Equals(0))
            {
                currentUser = 1;
            }

            else
            {
                currentUser = 0;
            }

            return currentUser;
        }
        private string isGameWon(string[,] board)
        {
            // check the rows :
            if ((board[0, 0] == "X" && board[0, 2] ==  "X" && board[0, 4] == "X") || (board[0, 0] == "O" && board[0, 2] == "O" && board[0, 4] == "O"))
            {
                displayWinner(board[0, 0]);
                return board[0, 0];
            }

            else if ((board[2, 0] == "X" && board[2, 2] == "X" && board[2, 4] == "X") || (board[2, 0] == "O" && board[2, 2] == "O" && board[2, 4] == "O"))
            {
                displayWinner(board[2, 0]);
                return board[2, 0];
            }

            else if ((board[4, 0] == "X" && board[4, 2] == "X" && board[4, 4] == "X") || (board[4, 0] == "O" && board[4, 2] == "O" && board[4, 4] == "O"))
            {
                displayWinner(board[4, 0]);
                return board[4, 0];
            }

            // check the columns :
            else if ((board[0, 0] == "X" && board[2, 0] == "X" && board[4, 0] == "X") || (board[0, 0] == "O" && board[2, 0] == "O" && board[4, 0] == "O"))
            {
                displayWinner(board[0, 0]);
                return board[0, 0];
            }

            else if ((board[0, 2] == "X" && board[2, 2] == "X" && board[4, 2] == "X") || (board[0, 2] == "O" && board[2, 2] == "O" && board[4, 2] == "O"))
            {
                displayWinner(board[2, 0]);
                return board[2, 0];
            }

            else if ((board[0, 4] == "X" && board[2, 4] == "X" && board[4, 4] == "X") || (board[0, 4] == "O" && board[2, 4] == "O" && board[4, 4] == "O"))
            {
                displayWinner(board[4, 0]);
                return board[4, 0];
            }

            // check the diagonal :
            else if ((board[0, 0] == "X" && board[2, 2] == "X" && board[4, 4] == "X") || (board[0, 0] == "O" && board[2, 2] == "O" && board[4, 4] == "O"))
            {
                displayWinner(board[0, 0]);
                return board[0, 0];
            }

            else if ((board[0, 4] == "X" && board[2, 2] == "X" && board[4, 0] == "X") || (board[0, 4] == "O" && board[2, 2] == "O" && board[4, 0] == "O"))
            {
                displayWinner(board[4, 0]);
                return board[4, 0];

            }
            else if (playerMoves.Count + computerMoves.Count == 9)
            {
                Console.WriteLine("The game was a tie.");
                    return "tie";
            }
            
            else { return ""; }
        }

        private void displayWinner(string winner)
        {
            string win = "";
            if (winner == "X")
            {
                win = "player";
            }
            else if (winner == "O")
            {
                win = "computer";
            }
            else 
            {
                win = "Error";
            }

            Console.WriteLine("Contragulations to {0} for winning the game", win);
        }
        private bool restartGame()
        {
            Console.WriteLine("Wanna play again?" + "\n" + "press y for trying again or n quitting the game");
            string result = Console.ReadLine();
            if (result == "y")
            {
                Console.Clear();
                isRunning = "";
                currentUser = 0;
                playerMoves.Clear();
                computerMoves.Clear();
                quitGame = false;
                return true;
            }
            else if (result == "n")
            {
                Console.Clear();
                Console.WriteLine("Thank you for playing :)");
                quitGame = true;
                return false;
            }
            else 
            {
                Console.Clear();
                Console.WriteLine("Something went wrong. Ending game");
                quitGame = true;
                return false;
            }

        }
    }
}
