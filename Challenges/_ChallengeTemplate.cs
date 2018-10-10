using System;
using System.Collections.Generic;

namespace Challenges
{
    public class ChallengeTemplate
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            var testCases = new List<int[]>()
            {
                new int[] { 2, 1, 5, 3, 4 },
                new int[] { 2, 5, 1, 3, 4 }
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

        public int Play(int[] arr)
        {
            return 0;
        }
    }
}
