using System;
using System.Collections.Generic;


namespace TicTacToe
{
    public class TicTacToeGame_Inspiration
    {
        string isRunning = "";
        int currentUser = 0;
        static List<int> playerMoves = new List<int>();
        static List<int> computerMoves = new List<int>();
        int computerPos;
        int playerPos;

        /// <summary>
        /// Initiates the game
        /// </summary>
        public void play()
        {
                string[,] board = createBoard();

                while (isRunning.Equals(""))
                {
                    //take players input and insert into the board
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

                    //compute a random move and insert into the board
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

        /// <summary>
        /// Creates the initial board
        /// </summary>
        /// <returns>
        /// a 2D string array containing the board values
        /// </returns>
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

        /// <summary>
        /// Prints the current board in the console
        /// </summary>
        /// <param name="board"></param>
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

        /// <summary>
        /// The method takes and checks if the given input is valid or
        /// asks for a new input if it is not valid
        /// </summary>
        /// <param name="board"></param>
        /// <returns>
        /// the coordinates of the move to be inserted in the board
        /// </returns>
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

        /// <summary>
        /// takes the coordinates from the move() and inserts the current player's
        /// symbol in the current board
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="board"></param>
        /// <param name="currentUser"></param>
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

            //insert the symbol at the given coordinates
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

        /// <summary>
        /// The method switches the current player
        /// </summary>
        /// <param name="currentUser"></param>
        /// <returns>
        /// Method returns the next player
        /// </returns>
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

        /// <summary>
        /// The method checks if either the player or computer has
        /// won the game
        /// </summary>
        /// <param name="board"></param>
        /// <returns>
        /// a string containing information either for who has won the game or "" which continues the game
        /// </returns>
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

            // check if game ended in a tie
            else if (playerMoves.Count + computerMoves.Count == 9)
            {
                Console.Clear();
                Console.WriteLine("The game was a tie.");
                printBoard(board);
                return "tie";
            }
            
            // continue the game
            else { return ""; }
        }

        /// <summary>
        /// displays winner message in the board
        /// </summary>
        /// <param name="winner"></param>
        /// <param name="board"></param>
        private void displayWinner(string winner, string [,] board)
        {
            string win;
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
