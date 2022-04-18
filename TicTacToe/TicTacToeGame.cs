﻿using System;
using System.Collections.Generic;


namespace TicTacToe
{
    public class Game
    {
        bool isRunning = false;
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
                
                int pos = move(board);
                insertMove(pos,board);
                printBoard(board);
            }
        }

        public int move(string[,] board)
        {
            Console.WriteLine("Please enter your placement (1-9):");
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

        public void insertMove(int pos, string[,] board)
        {
            switch (pos)
            {
                case 1:
                    if (board[0, 0] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                        board[0, 0] = "X";
                    break;
                case 2:
                    if (board[0, 2] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[0, 2] = "X";
                    break;
                case 3:
                    if (board[0, 4] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[0, 4] = "X";
                    break;
                case 4:
                    if (board[2, 0] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[2, 0] = "X";
                    break;
                case 5:
                    if (board[2, 2] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[2, 2] = "X";
                    break;
                case 6:
                    if (board[2, 4] == "X" || board[0, 0] == "O")
                    {

                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[2, 4] = "X";
                    break;
                case 7:
                    if (board[4, 0] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[4, 0] = "X";
                    break;
                case 8:
                    if (board[4, 2] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[4, 2] = "X";
                    break;
                case 9:
                    if (board[4, 4] == "X" || board[0, 0] == "O")
                    {
                        Console.Clear();
                        Console.WriteLine("This space is already taken. Try again");
                        return;
                    }
                    board[4, 4] = "X";
                    break;
                
                default:
                    break;
            }
            Console.Clear();
        }
              
    }
}
