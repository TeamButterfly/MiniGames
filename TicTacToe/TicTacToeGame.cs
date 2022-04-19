using System;
using System.Collections.Generic;


namespace TicTacToe
{
    public class Game
    {
        bool isRunning = false;
        string currentUser = "player";
        public string[,] createBoard()
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

        public void printBoard(string[,] board)
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

        public void play()
        {
            isRunning = true;
            string[,] board = createBoard();

            while (isRunning)
            {
                //method
                
                int pos = move(board, currentUser);
                insertMove(pos,board, currentUser);
                printBoard(board);
                currentUser = switchUser(currentUser);
                computerMove(board, currentUser);
                printBoard(board);
                currentUser = switchUser(currentUser);
            }
        }

        public int move(string[,] board, string currentUser)
        {
            Console.WriteLine("It is the {0}'s turn." +
                "Please enter your placement (1-9):", currentUser);
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
                else { correctInput = false; }
              
            }
            Console.Clear();
            return x;
        }

        public void insertMove(int pos, string[,] board, string currentUser)
        {
            string symbol = " ";
            if (currentUser.Equals("player"))
            {
                symbol = "X";
            }

            switch (pos)
            {
                case 1:
                    if (board[0, 0] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                        board[0, 0] = symbol;
                    break;
                case 2:
                    if (board[0, 2] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[0, 2] = symbol;
                    break;
                case 3:
                    if (board[0, 4] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[0, 4] = symbol;
                    break;
                case 4:
                    if (board[2, 0] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[2, 0] = symbol;
                    break;
                case 5:
                    if (board[2, 2] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[2, 2] = symbol;
                    break;
                case 6:
                    if (board[2, 4] == "X" || board[0, 0] == "O")
                    {

                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[2, 4] = symbol;
                    break;
                case 7:
                    if (board[4, 0] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[4, 0] = symbol;
                    break;
                case 8:
                    if (board[4, 2] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[4, 2] = symbol;
                    break;
                case 9:
                    if (board[4, 4] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[4, 4] = symbol;
                    break;
                
                default:
                    break;
            }
            Console.Clear();
        }

        public void computerMove(string[,] board, string currentUser) {
            string symbol = " ";
            if (currentUser.Equals("computer"))
            {
                symbol = "O";
            }

            Random rand = new Random();
            int pos = rand.Next(1, 10);

            switch (pos)
            {
                case 1:
                    if (board[0, 0] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[0, 0] = symbol;
                    break;
                case 2:
                    if (board[0, 2] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[0, 2] = symbol;
                    break;
                case 3:
                    if (board[0, 4] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[0, 4] = symbol;
                    break;
                case 4:
                    if (board[2, 0] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[2, 0] = symbol;
                    break;
                case 5:
                    if (board[2, 2] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[2, 2] = symbol;
                    break;
                case 6:
                    if (board[2, 4] == "X" || board[0, 0] == "O")
                    {

                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[2, 4] = symbol;
                    break;
                case 7:
                    if (board[4, 0] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[4, 0] = symbol;
                    break;
                case 8:
                    if (board[4, 2] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[4, 2] = symbol;
                    break;
                case 9:
                    if (board[4, 4] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[4, 4] = symbol;
                    break;

                default:
                    break;
            }
            Console.Clear();
        }

        public string switchUser(string currentUser) {
            if (currentUser.Equals("player")){
                currentUser = "computer";
            }

            else {
                currentUser = "player";
            }

            return currentUser;
        }
              
    }
}
