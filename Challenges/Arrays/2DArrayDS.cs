using System;
using System.Collections.Generic;

namespace Challenges
{
    public class TwoD_Array_DS
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            var testCases = new List<int[][]>()
            {
                new int[][] 
                {
                    new int[] { -9, -9, -9, 1, 1, 1 },
                    new int[] { 0, -9, 0, 4, 3, 2 },
                    new int[] { -9, -9, -9, 1, 2, 3 },
                    new int[] { 0, 0, 8, 6, 6, 0 },
                    new int[] { 0, 0, 0, -2, 0, 0 },
                    new int[] { 0, 0, 1, 2, 4, 0 }
                },
                new int[][]
                {
                    new int[] { 1, 1, 1, 0, 0, 0 },
                    new int[] { 0, 1, 0, 0, 0, 0 },
                    new int[] { 1, 1, 1, 0, 0, 0 },
                    new int[] { 0, 0, 2, 4, 4, 0 },
                    new int[] { 0, 0, 0, 2, 0, 0 },
                    new int[] { 0, 0, 1, 2, 4, 0 }
                }
            };

            for (int i = 0; i < testCases.Count; i++)
            {
                Console.WriteLine("Test case {0}", i + 1);
                Console.WriteLine("Input:");
                for (int j = 0; j < testCases[i].Length; j++)
                {
                    Console.WriteLine(string.Join(" ", testCases[i][j]));
                }
                    
                int result = Play(testCases[i]);
                Console.WriteLine("{1}Result: {0}{1}", result, Environment.NewLine);
            }

            Console.ReadLine();
        }

        public int Play(int[][] arr)
        {
            int maxSum = int.MinValue;
            int hourGlassSize = 3;
            int maxArrayIndex = arr.Length - hourGlassSize;

            Console.WriteLine("{0}All sums:", Environment.NewLine);

            for (int outerI = 0; outerI <= maxArrayIndex; outerI++)
            {
                for (int outerJ = 0; outerJ <= maxArrayIndex; outerJ++)
                {
                    int localSum = 0;

                    for (int innnerI = outerI; innnerI < outerI + hourGlassSize; innnerI++)
                    {
                        for (int innnerJ = outerJ; innnerJ < outerJ + hourGlassSize; innnerJ++)
                        {
                            localSum += arr[innnerI][innnerJ];
                        }
                    }

                    localSum -= arr[outerI + 1][outerJ];
                    localSum -= arr[outerI + 1][outerJ + 2];

                    Console.Write("{0} ", localSum);

                    if (localSum > maxSum)
                        maxSum = localSum;
                }

                Console.WriteLine();
            }            

            return maxSum;
        }
    }
}
