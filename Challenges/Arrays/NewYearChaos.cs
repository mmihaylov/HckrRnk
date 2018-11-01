using System;
using System.Collections.Generic;

namespace Challenges
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/new-year-chaos/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays
    /// Medium
    /// </summary>
    public class NewYearChaos
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            var testCases = new List<int[]>()
            {
                new int[] { 2, 1, 5, 3, 4 },
                new int[] { 2, 5, 1, 3, 4 },
                new int[] { 5, 1, 2, 3, 7, 8, 6, 4 },
                new int[] { 1, 2, 5, 3, 7, 8, 6, 4 },
                new int[] { 1, 2, 5, 3, 4, 7, 8, 6 }
            };


            for (int i = 0; i < testCases.Count; i++)
            {
                Console.WriteLine("Test case {0}", i + 1);
                Console.WriteLine("Input: {0}", string.Join(" ", testCases[i]));
                int result = Play(testCases[i]);
                Console.WriteLine("Result: {0}{1}", result, Environment.NewLine);
            }

            Console.ReadLine();
        }

        //public int Play(int[] q)
        //{
        //    int size = q.Length;
        //    int swaps = 0;
        //    bool chaotic = false;
                        
        //    for (int i = 0; i < size; i++)
        //    {
        //        // Check for too chaotic first
        //        if ((q[i] - (i + 1)) > 2) {
        //            chaotic = true;
        //            break;
        //        }

        //        //if (q[i] == i + 1)
        //        //    continue;                    

        //        for (int j = i + 1; j < size; j++)
        //        {                    
        //            if (q[i] > q[j])
        //            {
        //                // VERY SMART, no need to sort but just count the swaps                        
        //                swaps++;
        //            }
        //        }
        //    }

        //    return chaotic ? -1 : swaps;
        //}

        public int Play(int[] q)
        {            
            int swaps = 0;
            bool chaotic = false;

            for (int i = q.Length - 1; i >= 0; i--)
            {
                // Check for too chaotic first
                if ((q[i] - (i + 1)) > 2)
                {
                    chaotic = true;
                    break;
                }
                                
                for (int j = Math.Max(0, q[i] - 2); j < i; j++)
                {
                    if (q[j] > q[i])
                        swaps++;
                }
            }

            return chaotic ? -1 : swaps;
        }
    }
}
