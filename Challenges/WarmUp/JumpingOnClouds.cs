using System;
using System.Collections.Generic;

namespace Challenges
{
    public class JumpingOnClouds
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            var testCases = new List<int[]>()
            {
                new int[] { 0, 0, 0, 0, 1, 0 },
                new int[] { 0, 1, 0, 0, 1, 0, 1, 0 }
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

        public int Play(int[] c)
        {
            int index = 0;
            int numberOfJumps = 0;
            int lastPossibleCloudIndex = c.Length - 1;

            while (true)
            {
                // Check if we don't exceed cloud indexes lenght and we don't jump on 1
                if (index + 2 <= lastPossibleCloudIndex && c[index + 2] == 0)
                {
                    index += 2;
                }
                else
                {
                    index++;
                }

                numberOfJumps++;

                if (index == lastPossibleCloudIndex)
                    break;
            }

            return numberOfJumps;
        }
    }
}
