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
    public class SPGame
    {
        int n;
        int[] arr, sol;
        int amountOfMoves;

        public void play()
        {
            amountOfMoves = 0;
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
            {
                Console.WriteLine("The size isn't a squared size, try again");
                setup();
            }

            createboard();
            display();
            solution();
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

        }


        public void display()
        {
            int ss = Convert.ToInt32(Math.Sqrt(arr.Length));

            //printing the matrix board
            Console.WriteLine("Board");
            for(int i = 0; i < n; i++)
            {
                if (i % ss == 0 && i != 0)
                {
                    Console.WriteLine(" ");
                }
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine(" ");
        }

        public void move()
        {
            Console.WriteLine("Type the value of the tiles you want to move. It has to be neighbor with 0");
            int swapvalue = Convert.ToInt32(Console.ReadLine());

            //checks if tile n is neighbor with 0, if not try again
            if (isNeighbor(swapvalue))
                swap(swapvalue);
            else
            {
                Console.WriteLine("The tile you want to move isn't neighbor with 0, try again");
                move();
            }
        }

        public bool isNeighbor(int swapvalue)
        {
            List<int> zerosNeighbors = new List<int>();
            int s = arr.Length;
            int ss = Convert.ToInt32(Math.Sqrt(arr.Length));

            //find neighbors
            for (int i = 0; i<s; i++)
            {
                //first row that isn't the edges
                if(i < ss && ((i%ss !=0) || (i % ss !=n-1)) && arr[i] == 0) 
                {
                    //left corner
                    if(arr[0] == 0)
                    {
                        zerosNeighbors.Add(arr[i + 1]);
                        zerosNeighbors.Add(arr[i + ss]);
                        break;
                    }
                    //right corner
                    if (arr[ss-1] == 0)
                    {
                        zerosNeighbors.Add(arr[i - 1]);
                        zerosNeighbors.Add(arr[i + ss]);
                        break;
                    }
                    if (arr[i] == 0)
                    {
                        zerosNeighbors.Add(arr[i - 1]);
                        zerosNeighbors.Add(arr[i + 1]);
                        zerosNeighbors.Add(arr[i + ss]);
                        break;
                    }
                }
                //middle, but not the left and right edges
                if (i>=ss && i<s-ss && arr[i] == 0)
                {
                    //left
                    if(i % ss == 0)
                    {
                        zerosNeighbors.Add(arr[i + 1]);
                        zerosNeighbors.Add(arr[i - ss]);
                        zerosNeighbors.Add(arr[i + ss]);
                        break;
                    }
                    //right
                    if (i % ss == ss - 1)
                    {
                        zerosNeighbors.Add(arr[i - 1]);
                        zerosNeighbors.Add(arr[i - ss]);
                        zerosNeighbors.Add(arr[i + ss]);
                        break;
                    }
                    else
                    {
                        zerosNeighbors.Add(arr[i - 1]);
                        zerosNeighbors.Add(arr[i + 1]);
                        zerosNeighbors.Add(arr[i - ss]);
                        zerosNeighbors.Add(arr[i + ss]);
                        break;
                    }
                }
                //last row that isn't the edges
                if (i >= (s - ss))
                { 
                    //left corner
                    if (i == s-ss && arr[i] == 0)
                    {
                        zerosNeighbors.Add(arr[i + 1]);
                        zerosNeighbors.Add(arr[i - ss]);
                        break;
                    }
                    //right corner
                    if (i == s - 1 && arr[i] == 0)
                    {
                        zerosNeighbors.Add(arr[i - 1]);
                        zerosNeighbors.Add(arr[i - ss]);
                        break;
                    }
                    if (arr[i] == 0)
                    {
                        zerosNeighbors.Add(arr[i - 1]);
                        zerosNeighbors.Add(arr[i + 1]);
                        zerosNeighbors.Add(arr[i - ss]);
                        break;
                    }
                }
            }

            if(zerosNeighbors.Contains(swapvalue))
                return true;
            else
                return false;

        }
        public void swap(int swapvalue)
        {
            countAmountOfMoves();
            //swapping n with 0
            int temp;
            int zero = 0;
            int swapindex = 0;
            for (int i = 0; i < arr.Length; i++)
             {
                if (arr[i] == 0)
                {
                    zero = i;
                }
                if (arr[i] == swapvalue)
                {
                    swapindex = i;
                }

            }
            arr[zero] = swapvalue;
            arr[swapindex] = 0;

            display();
        }
        public void countAmountOfMoves()
        {
            amountOfMoves += 1;
        }
        public void solution()
        {
            int ss = Convert.ToInt32(Math.Sqrt(arr.Length));
            sol = new int[n];

            for (int i = 0; i < n; i++)
            {
                if(i == n-1)
                    sol[i] = 0;
                else
                    sol[i] = i+1;
            }
        }
        public bool isComplited()
        {
            if (arr.SequenceEqual(sol))
            {
                Console.WriteLine("what a big boi, you solved the slide puzzle!");
                Console.WriteLine("You used " + amountOfMoves + " moves, to solve the puzzle");
                return false;
            }
            return true;
        }

        public int getPoints()
        {
            return amountOfMoves/2;
        }
    }
}
