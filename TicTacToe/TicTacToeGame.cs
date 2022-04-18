using System;
using System.Collections.Generic;


namespace TicTacToe
{
    public class Game
    {

        public void createBoard()
        {

            string[,] board = {
            {" ", "|", " ", "|", " "},
            {"-", "+", "-", "+", "-"},
            {" ", "|", " ", "|", " "},
            {"-", "+", "-", "+", "-"},
            {" ", "|", " ", "|", " "}
            };

            for(int i = 0; i < 5; i++){
                for (int j = 0; j < 5; j++){

                    Console.Write(board[i,j]);
                }
                Console.WriteLine();
            }

        }
              
    }
}
