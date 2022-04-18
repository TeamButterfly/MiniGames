using System;
using System.Collections.Generic;


namespace TicTacToe
{
    public class Game
    {
        bool isRunning = false;
        public void createBoard()
        {

            string[,] board = {
            {" ", "|", " ", "|", " "},
            {"-", "+", "-", "+", "-"},
            {" ", "|", " ", "|", " "},
            {"-", "+", "-", "+", "-"},
            {" ", "|", " ", "|", " "}
            };

            printBoard(board);
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

            while (isRunning)
            {
                //method
            }
        }
              
    }
}
