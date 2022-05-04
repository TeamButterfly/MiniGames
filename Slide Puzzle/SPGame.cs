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
        public static int FindIndex<T>(this T[] array, T item)
        {
            return Array.IndexOf(array, item);
        }
    }
    public class SPGame
    {
        private int n, invCounter;
        private int[] arr, sol;
        private int amountOfMoves;

        public int BoardSize(int n)
        {
            //check if input size is squarable
            if (!((Math.Sqrt(n) % 1) == 0))
                return n;
            else
                return 0;
        }

        public int[] CreateBoard(int n)
        {
            this.n = n;
            amountOfMoves = 0;

            //creating every tile
            arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                if(i == n - 1)
                {
                    arr[i] = 0;
                }else
                    arr[i] = i+1;
            }

            //swap the values based on the move method, for checking if the tiles i neighbor
            Random rand = new Random();
            for (int i = 0; i < 500; i++)
            {
                var k = rand.Next(1, arr.Length);
                Move(k);
            }

            return arr;
        }

        public int[] Move(int swapvalue)
        {
            //checks if tile n is neighbor with 0, if not try again
            if (IsNeighbor(swapvalue))
                Swap(swapvalue);
            else
                Console.WriteLine("The tile you want to move isn't neighbor with 0, try again");
            return arr;
        }

        public bool IsNeighbor(int swapvalue)
        {
            var zerosNeighbors = new List<int>();
            var s = arr.Length;
            var ss = Convert.ToInt32(Math.Sqrt(arr.Length));

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
        public void Swap(int swapvalue)
        {
            CountAmountOfMoves();
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
        }
        public void CountAmountOfMoves()
        {
            amountOfMoves += 1;
        }
        public void Solution()
        {
            sol = new int[n];

            for (int i = 0; i < n; i++)
            {
                if(i == n-1)
                    sol[i] = 0;
                else
                    sol[i] = i+1;
            }
        }
        public bool IsCompleted()
        {
            Solution();
            if (arr.SequenceEqual(sol))
                return true;
            return false;
        }

        public int GetScore()
        {
            return amountOfMoves;
        }
    }
}
