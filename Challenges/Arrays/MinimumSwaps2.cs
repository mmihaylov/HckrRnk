using System;
using System.Collections.Generic;

namespace Challenges
{
    public class MinimumSwaps2
    {
        // URL: https://www.hackerrank.com/challenges/minimum-swaps-2/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays
        // Return the minimum number of swaps to order the array

        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            var testCases = new List<Tuple<int[], int>>()
            {
                Tuple.Create(new int[] { 4, 3, 1, 2 }, 3),
                Tuple.Create(new int[] { 2, 3, 4, 1, 5 }, 3),
                Tuple.Create(new int[] { 1, 3, 5, 2, 4, 6, 8 }, 3),
                Tuple.Create(new int[] { 7, 1, 3, 2, 4, 5, 6 }, 5)
            };

            for (int i = 0; i < testCases.Count; i++)
            {
                Console.WriteLine("Test case {0}", i + 1);
                Console.WriteLine("Input: {0}", string.Join(" ", testCases[i].Item1));
                int result = Play(testCases[i].Item1);
                Console.WriteLine("Result: {0} [{1}]{2}", result, result == testCases[i].Item2 ? "CORRECT" : "FAIL", Environment.NewLine);
            }

            Console.ReadLine();
        }

        public int Play(int[] arr)
        {
            int swaps = 0;                        
            for (int i = 0; i < arr.Length - 1; i++)
            {
                while (arr[i] != i + 1) {
                    int temp = arr[arr[i] - 1];
                    arr[arr[i] - 1] = arr[i];
                    arr[i] = temp;
                    swaps++;
                }
            }

            return swaps;
        }        
    }
}
