using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide_Puzzle
{
    public static class Extensions
    {
        public static int findIndex<T>(this T[] array, T item)
        {
            return Array.IndexOf(array, item);
        }
    }
    class Game
    {
        int n;
        int[] arr;
        int[,] matrix;
        int[] arrSolution;
        int[,] matrixSolution;
        int xCoordinat, yCoordinat, xCoordinatTemp, yCoordinatTemp;

        public void play()
        {
            while (isComplited())
            {
                move();
            }
        }

        public void setup()
        {
            Console.WriteLine("how big do you want it? >:) it has to be squared tho");
            n = Convert.ToInt32(Console.ReadLine());

            //checks if the input is squared
            if (!((Math.Sqrt(n) % 1) == 0))
                setup();

            createboard();
            display();
            solution();
            play();
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

        public void move()
        {
            Console.WriteLine("Type the value of the tiles you want to move. It has to be neighbor with 0");
            n = Convert.ToInt32(Console.ReadLine());

            //checks if tile n is neighbor with 0, if not try again

            if (isNeighbor(n))
                swap(n);
            else 
                move();
        }

        public bool isNeighbor(int n)
        {
            //getting the position of 0
            for (int x = 0; x < Math.Sqrt(arr.Length); ++x)
            {
                for (int y = 0; y < Math.Sqrt(arr.Length); ++y)
                {
                    if (matrix[x, y] == 0)
                    {
                        xCoordinat = x;
                        yCoordinat = y;
                    }
                }
            }
            Console.WriteLine(matrix[xCoordinat + 1, yCoordinat] + " " +
                matrix[xCoordinat - 1, yCoordinat] + " " +
                matrix[xCoordinat, yCoordinat + 1] + " " +
                matrix[xCoordinat, yCoordinat - 1]);

            List<int> isBoardEdge = new List<int>();
            //finding board edge
            for (int x = 0; x < Math.Sqrt(arr.Length); ++x)
            {
                for (int y = 0; y < Math.Sqrt(arr.Length); ++y)
                {
                    if((y == 0 || 
                        x == (n - 1) || 
                        (x == 0 && y != 3) || 
                        y == (n - 1)))
                        isBoardEdge.Add(matrix[x,y]);
                }
            }


            //wrong 
            if (n == matrix[xCoordinat + 1, yCoordinat] ||
                n == matrix[xCoordinat - 1, yCoordinat] ||
                n == matrix[xCoordinat, yCoordinat + 1] ||
                n == matrix[xCoordinat, yCoordinat - 1])
            {
                
                return true;
            }
            else
                return false;
        }
        public void swap(int n)
        {
            
            //swapping n with 0
            for (int x = 0; x < Math.Sqrt(arr.Length); ++x)
            {
                for (int y = 0; y < Math.Sqrt(arr.Length); ++y)
                {
                    if (matrix[x, y] == 0)
                    {
                        xCoordinat = x;
                        yCoordinat = y;
                    }
                    if (matrix[x, y] == n)
                    {
                        xCoordinatTemp = x;
                        yCoordinatTemp = y;
                    }
                }
            }
            matrix[xCoordinat,yCoordinat] = matrix[xCoordinatTemp,yCoordinatTemp];
            matrix[xCoordinatTemp, yCoordinatTemp] = 0;
        }
        public void solution()
        {
            Console.WriteLine("solution");
            /*matrixSolution = new int[n, n];
            int counter = 0;

            for (int i = 0; i < Math.Sqrt(n); i++)
            {
                for (int j = 0; j < Math.Sqrt(n); j++)
                {
                    matrixSolution[i, j] = counter;
                    //printing the solution
                    Console.Write(matrixSolution[i, j] + " ");
                    counter++;
                }
                Console.WriteLine(" ");
            }*/

            //creating every tile
            arrSolution = new int[n];
            for (int i = 0; i < n; i++)
            {
                arrSolution[i] = i + 1;
                if (arrSolution[i] == n)
                    arrSolution[i] = 0;
            }

            matrixSolution = new int[n, n];
            int counter = 0;
            for (int i = 0; i < Math.Sqrt(n); i++)
            {
                for (int j = 0; j < Math.Sqrt(n); j++)
                {
                    matrixSolution[i, j] = arrSolution[counter];
                    //printing the solution
                    Console.Write(matrixSolution[i, j] + " ");
                    counter++;
                }
                Console.WriteLine(" ");
            }
        }

        public bool isComplited()
        {
            if (matrix.Equals(matrixSolution)){ 
                Console.WriteLine("what a big boi, you solved the slide puzzle!");
                return false;
            }
            return true;
        }
    }
}
