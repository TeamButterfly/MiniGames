using System;
using System.Collections.Generic;


namespace TicTacToe
{
    public class Game
    {
        bool isRunning = false;
        string currentUser = "player";
        List<int> playerMoves = new List<int>();
        List<int> computerMoves = new List<int>();
        int computerPos;
        int playerPos;

        public void play()
        {
            isRunning = true;
            string[,] board = createBoard();

            while (isRunning)
            {
                //player's move and make it's move
                int playerPos = move(board, currentUser); 
                while (playerMoves.Contains(playerPos) || computerMoves.Contains(playerPos)) { 
                    Console.WriteLine("That position is already taken. Try again!");
                    printBoard(board);
                    playerPos = move(board, currentUser);
                }

                insertMove(playerPos, board, currentUser);
                printBoard(board);
                playerMoves.Add(playerPos);
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
                currentUser = switchUser(currentUser);
            }
        }

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
                else {
                    correctInput = false; }
              
            }
            Console.Clear();
            return x;
        }

        public void insertMove(int pos, string[,] board, string currentUser) {
            string symbol = " ";

            if (currentUser.Equals("player")) 
            { 
                symbol = "X"; 
            }

            else if (currentUser.Equals("computer")) 
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

        public string switchUser(string currentUser) {
            if (currentUser.Equals("player")){
                currentUser = "computer";
            }

            else {
                currentUser = "player";
            }

            return currentUser;
        }
        public bool isGameWon(){ 
        List<int> top = new List<int>();


            return false;
        }
    }
}
