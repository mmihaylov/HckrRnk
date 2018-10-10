using System;
using System.Collections.Generic;

namespace Challenges
{
    public class LeftRotation
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            var testCases = new List<Tuple<int, int[]>>()
            {
                Tuple.Create(4, new int[] { 1, 2, 3, 4, 5 }),
                Tuple.Create(10, new int[] { 41, 73, 89, 7, 10, 1, 59, 58, 84, 77, 77, 97, 58, 1, 86, 58, 26, 10, 86, 51 }),
                Tuple.Create(13, new int[] { 33, 47, 70, 37, 8, 53, 13, 93, 71, 72, 51, 100, 60, 87, 97 }),
            };


            for (int i = 0; i < testCases.Count; i++)
            {
                Console.WriteLine("Test case {0}", i + 1);
                Console.WriteLine("Input: {0} | {1}", testCases[i].Item1, string.Join(" ", testCases[i].Item2));
                int[] result = Play(testCases[i].Item2, testCases[i].Item1);
                Console.WriteLine("Result: {0}{1}", string.Join(" ", result), Environment.NewLine);
            }

            Console.ReadLine();
        }

        public int[] Play(int[] a, int d)
        {
            int size = a.Length;
            int[] result = new int[size];

            for (int i = 0; i < size; i++)
            {                
                //int adjustedIndex = i - d;
                //if (adjustedIndex < 0)
                //    adjustedIndex += size;

                // Refactored approach
                int adjustedIndex = (i - d + size) % size;                
                result[adjustedIndex] = a[i];
            }

            return result;
        }
    }
}
