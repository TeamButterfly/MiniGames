using System;
using System.Collections.Generic;


// TODOs : insert comments and descriptions to the methods/class 
//         Optimer koden 

namespace TicTacToe
{
    public class TicTacToeGame
    {
        string isRunning = "";
        int currentUser = 0;
        static List<int> playerMoves = new List<int>();
        static List<int> computerMoves = new List<int>();
        int computerPos;
        int playerPos;


        public void play()
        {

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
            int x = 0;
            bool correctInput = false;

            while (correctInput == false)
            {
                Console.WriteLine("It is the player's turn. " +
                "Please enter your placement (1-9):");
                try
                {
                    x = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            
                if (x >= 1 && x <= 9)
                {
                    correctInput = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid move please try again.");
                    printBoard(board);
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
                displayWinner(board[0, 0], board);
                return board[0, 0];
            }

            else if ((board[2, 0] == "X" && board[2, 2] == "X" && board[2, 4] == "X") || (board[2, 0] == "O" && board[2, 2] == "O" && board[2, 4] == "O"))
            {
                displayWinner(board[2, 0], board);
                return board[2, 0];
            }

            else if ((board[4, 0] == "X" && board[4, 2] == "X" && board[4, 4] == "X") || (board[4, 0] == "O" && board[4, 2] == "O" && board[4, 4] == "O"))
            {
                displayWinner(board[4, 0], board);
                return board[4, 0];
            }

            // check the columns :
            else if ((board[0, 0] == "X" && board[2, 0] == "X" && board[4, 0] == "X") || (board[0, 0] == "O" && board[2, 0] == "O" && board[4, 0] == "O"))
            {
                displayWinner(board[0, 0], board);
                return board[0, 0];
            }

            else if ((board[0, 2] == "X" && board[2, 2] == "X" && board[4, 2] == "X") || (board[0, 2] == "O" && board[2, 2] == "O" && board[4, 2] == "O"))
            {
                displayWinner(board[0, 2], board);
                return board[0, 2];
            }

            else if ((board[0, 4] == "X" && board[2, 4] == "X" && board[4, 4] == "X") || (board[0, 4] == "O" && board[2, 4] == "O" && board[4, 4] == "O"))
            {
                displayWinner(board[0, 4], board);
                return board[0, 4];
            }

            // check the diagonal :
            else if ((board[0, 0] == "X" && board[2, 2] == "X" && board[4, 4] == "X") || (board[0, 0] == "O" && board[2, 2] == "O" && board[4, 4] == "O"))
            {
                displayWinner(board[0, 0], board);
                return board[0, 0];
            }

            else if ((board[0, 4] == "X" && board[2, 2] == "X" && board[4, 0] == "X") || (board[0, 4] == "O" && board[2, 2] == "O" && board[4, 0] == "O"))
            {
                displayWinner(board[0, 4], board);
                return board[0, 4];

            }
            else if (playerMoves.Count + computerMoves.Count == 9)
            {
                Console.Clear();
                Console.WriteLine("The game was a tie.");
                printBoard(board);
                return "tie";
            }
            
            else { return ""; }
        }

        private void displayWinner(string winner, string [,] board)
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
            Console.Clear();
            Console.WriteLine("Contragulations to {0} for winning the game", win);
            printBoard(board);
        }
    }
}
