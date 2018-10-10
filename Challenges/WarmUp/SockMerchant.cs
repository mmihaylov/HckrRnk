using System;
using System.Collections.Generic;

namespace Challenges
{
    public class SockMerchant
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            var testCases = new List<int[]>()
            {
                new int[] { 10, 20, 20, 10, 10, 30, 50, 10, 20 },
                new int[] { 1, 1, 3, 1, 2, 1, 3, 3, 3, 3 }
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

        public int Play(int[] socksPile)
        {
            Dictionary<int, int> groupedSocks = new Dictionary<int, int>();
            int pairsFound = 0;

            foreach (var sock in socksPile)
            {                
                if (groupedSocks.ContainsKey(sock))
                {
                    pairsFound++;
                    groupedSocks.Remove(sock);
                }
                else
                    groupedSocks.Add(sock, 1);
            }

            return pairsFound;
        }
    }
}
