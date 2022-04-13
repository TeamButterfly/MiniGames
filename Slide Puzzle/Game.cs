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
    public class Game
    {
        int n, amountOfMoves;
        int[] arr, sol;

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
            n = Convert.ToInt32(Console.ReadLine());

            //checks if tile n is neighbor with 0, if not try again
            if (isNeighbor(n))
                swap(n);
            else
            {
                Console.WriteLine("The tile you want to move isn't neighbor with 0, try again");
                move();
            }
        }

        public bool isNeighbor(int n)
        {
            List<int> zerosNeighbors = new List<int>();
            int s = arr.Length;
            int ss = Convert.ToInt32(Math.Sqrt(arr.Length));

            //find neighbors
            for (int i = 0; i<s; i++)
            {
                //first row that isn't the edges
                if(i < ss && ((i%ss !=0) || (i % ss !=n-1))) 
                {
                    if(arr[i] == 0)
                    {
                        zerosNeighbors.Add(arr[i - 1]);
                        zerosNeighbors.Add(arr[i + 1]);
                        zerosNeighbors.Add(arr[i + ss]);
                    }
                    //left corner
                    if(arr[0] == 0)
                    {
                        zerosNeighbors.Add(arr[i + 1]);
                        zerosNeighbors.Add(arr[i + ss]);
                    }
                    //right corner
                    if (arr[ss-1] == 0)
                    {
                        zerosNeighbors.Add(arr[i - 1]);
                        zerosNeighbors.Add(arr[i + ss]);
                    }
                }
                //middle, but not the left and right edges
                if (i>ss && i<s-ss && arr[i] == 0)
                {
                    //left
                    if(i % ss == 0)
                    {
                        zerosNeighbors.Add(arr[i + 1]);
                        zerosNeighbors.Add(arr[i - ss]);
                        zerosNeighbors.Add(arr[i + ss]);
                    }
                    //right
                    if(i % ss != ss - 1)
                    {
                        zerosNeighbors.Add(arr[i - 1]);
                        zerosNeighbors.Add(arr[i - ss]);
                        zerosNeighbors.Add(arr[i + ss]);
                    }
                    zerosNeighbors.Add(arr[i - 1]);
                    zerosNeighbors.Add(arr[i + 1]);
                    zerosNeighbors.Add(arr[i - ss]);
                    zerosNeighbors.Add(arr[i + ss]);
                }
                //last row that isn't the edges
                if (i>(s - ss))
                {
                    if (arr[i] == 0)
                    {
                        zerosNeighbors.Add(arr[i - 1]);
                        zerosNeighbors.Add(arr[i + 1]);
                        zerosNeighbors.Add(arr[i - ss]);
                    }
                    //left corner
                    if (arr[s-ss] == 0)
                    {
                        zerosNeighbors.Add(arr[i + 1]);
                        zerosNeighbors.Add(arr[i - ss]);
                    }
                    //right corner
                    if (arr[s - 1] == 0)
                    {
                        zerosNeighbors.Add(arr[i - 1]);
                        zerosNeighbors.Add(arr[i - ss]);
                    }
                }
            }

            if(zerosNeighbors.Contains(n))
                return true;
            else
                return false;

        }
        public void swap(int n)
        {
            getAmountOfMoves();
            //swapping n with 0
            int temp;
            int zero = 0;
            for(int i = 0; i < n; i++)
            {
                if (arr[i] == 0)
                {
                    zero = i;
                    break;
                }
            }
            temp = zero;
            arr[zero] = n;
            arr[n] = temp;

            display();
        }
        public int getAmountOfMoves()
        {
            return amountOfMoves =+ 1;
        }
        public void solution()
        {
            Console.WriteLine("solution");
            int ss = Convert.ToInt32(Math.Sqrt(arr.Length));
            sol = new int[n];

            for (int i = 0; i < n; i++)
            {
                if(i == n-1)
                    sol[i] = 0;
                else
                    sol[i] = i+1;
            }

            //printing the solution
            for (int i = 0; i < n; i++)
            {
                if (i % ss == 0 && i != 0)
                {
                    Console.WriteLine(" ");
                }
                Console.Write(sol[i] + " ");
            }
            Console.WriteLine(" ");
        }
        public bool isComplited()
        {
            if (arr.Equals(sol))
            {
                Console.WriteLine("what a big boi, you solved the slide puzzle!");
                return false;
            }
            return true;
        }

        public void getPoints()
        {
            getAmountOfMoves();
        }
    }
}
