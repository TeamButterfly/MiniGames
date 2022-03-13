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
        int n;
        int[] arr;
        int[,] matrix;

        public void setup()
        {
            Console.WriteLine("how big do you want it? >:) it has to be squared tho");
            n = Convert.ToInt32(Console.ReadLine());

            createboard();
            display();   
        }

        public void createboard()
        {
            //creating every tile
            arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = i;
            }

            Random rand = new Random();

            // For each spot in the array, pick
            // a random item to swap into that spot.
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int j = rand.Next(i, arr.Length);
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

            matrix = new int[n, n];
            int counter = 0;

            //creating the matrix with swapped values
            for (int i = 0; i < Math.Sqrt(arr.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(arr.Length); j++)
                {
                    matrix[i, j] = arr[counter];
                    counter++;
                }
            }
        }


        public void display()
        {
            //printing the matrix
            Console.WriteLine("Board");
            for (int row = 0; row < Math.Sqrt(arr.Length); row++)
            {
                for (int col = 0; col < Math.Sqrt(arr.Length); col++)
                {
                    Console.Write(matrix[row, col].ToString() + " ");
                }
                Console.WriteLine(" ");
            }
        }

        public void solution()
        {
            Console.WriteLine("solution");
            matrix = new int[n, n];
            int counter = 0;

            for (int i = 0; i < Math.Sqrt(n); i++)
            {
                for (int j = 0; j < Math.Sqrt(n); j++)
                {
                    matrix[i, j] = counter;
                    //printing the solution
                    Console.Write(matrix[i, j] + " ");
                    counter++;
                }
                Console.WriteLine(" ");
            }
        }
    }
}
