using System;
using System.Collections.Generic;

namespace Challenges
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/crush/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays
    /// Hard
    /// <![CDATA[
    /// Here we are using difference array. The complexity of this approach is O(1) and is much faster. 
    /// Difference array D[i] of a given array A[i] is defined as D[i] = A[i]-A[i-1] (for 0 < i < N ) and D[0] = A[0] considering 0 based indexing. This array 
    /// can be used to perform range update queries "l r x" where l is left index, r is right index and x is value to be added and after all 
    /// queries you can return original array from it. Where update range operations can be performed in O(1) complexity.
    /// ]]>
    /// For simplicity we'll use 0-based arrays below
    /// </summary>
    public class ArrayManipulation
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            var testCases = new List<Tuple<int, int[][]>>()
            {
                Tuple.Create(5, new int[][] {
                                            new int[3] { 0, 1, 100 },
                                            new int[3] { 1, 4, 300 },
                                            new int[3] { 2, 3, 500 } }),
                Tuple.Create(6, new int[][] {
                                            new int[3] { 0, 2, 100 },
                                            new int[3] { 1, 5, 100 },
                                            new int[3] { 2, 3, 100 } })
            };

            //var largeTestCase = GenerateLargeTestCase(10000000, 100000);
            //testCases.Add(largeTestCase);

            for (int i = 0; i < testCases.Count; i++)
            {
                Console.WriteLine("Test case {0}", i + 1);
                Console.WriteLine("Input: {0}", testCases[i].Item1);
                for (int j = 0; j < testCases[i].Item2.Length; j++)
                {
                    Console.Write("       ");
                    Helpers.PrintArray(testCases[i].Item2[j]);
                }

                long result = Play(testCases[i].Item1, testCases[i].Item2);
                Console.WriteLine("Result: {0}", result);
                Console.WriteLine();
            }

            Console.ReadLine();
        }        

        public long Play(int n, int[][] queries)
        {
            long[] diffArray = new long[n];

            for (int i = 0; i < queries.Length; i++)
            {                
                int a = queries[i][0];
                int b = queries[i][1];
                long k = queries[i][2];

                diffArray[a] += k;
                if (b + 1 < n)
                    diffArray[b + 1] -= k;
            }

            Console.Write("Difference array: ");
            Helpers.PrintArray<long>(diffArray);

            var arr = ConvertDifferenceArrayToOriginal(diffArray);
            Console.Write("Original array: ");
            Helpers.PrintArray<long>(arr);

            long tempMax = 0;
            long max = 0;
            for (int i = 1; i < n; i++)
            {
                tempMax += diffArray[i];
                if (tempMax > max)
                    max = tempMax;
            }

            return max;
        }
          

        private Tuple<int, int[][]> GenerateLargeTestCase(int n, int queriesCount)
        {
            var queries = new int[queriesCount][];
            var random = new Random();
            for (int i = 0; i < queriesCount; i++)
            {
                int startIndex = random.Next(0, n);
                int endIndex = random.Next(startIndex, n);
                int value = random.Next(0, 1000000000);
                queries[i] = new int[] { startIndex, endIndex, value };
            }

            return Tuple.Create(n, queries);
        }

        private static long[] ConvertDifferenceArrayToOriginal(long[] diffArr)
        {
            var arr = new long[diffArr.Length];

            //D[i] = A[i]-A[i-1]
            // e.g. A[i] = D[i] + A[i-1];

            arr[0] = diffArr[0];
            for (int i = 1; i < diffArr.Length; i++)
            {
                arr[i] = diffArr[i] + arr[i - 1];
            }

            return arr;
        }
    }
}
