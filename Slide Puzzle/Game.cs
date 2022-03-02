using Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide_Puzzle
{
    class Game
    {
        int[,] array;
        int n;
        public void setup()
        {
            Console.WriteLine("how big do you want it? >:)");
            n = Convert.ToInt32(Console.ReadLine());
            //int[] temp = temp[n];

            for (int i = 0; i < n; i++)
                //temp[i] = i;

            array = new int[n, n];
            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = counter;
                    counter++;
                }
            }
        }

        public void display()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j].ToString() + " ");
                }
                Console.WriteLine("");
            }
        }

        public void solution()
        {
            array = new int[n, n];
            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = counter;
                    counter++;
                }
            }
        }
    }
}
