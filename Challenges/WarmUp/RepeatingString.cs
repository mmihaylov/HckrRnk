using System;
using System.Collections.Generic;

namespace Challenges
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/repeated-string/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=warmup
    /// Easy
    /// </summary>
    public class RepeatingString
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            var testCases = new List<Tuple<string, long>>()
            {
                Tuple.Create("aba", 10L),
                Tuple.Create("a", 1000000000000)
            };


            for (int i = 0; i < testCases.Count; i++)
            {
                Console.WriteLine("Test case {0}", i + 1);
                Console.WriteLine("Input: {0}", string.Join(" ", testCases[i].Item1, testCases[i].Item2));
                long result = Play(testCases[i].Item1, testCases[i].Item2);
                Console.WriteLine("Result: {0}{1}", result, Environment.NewLine);
            }

            Console.ReadLine();
        }

        public long Play(string s, long n)
        {
            long countA = 0;

            // Find letter a in single word
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                    countA++;
            }

            long possibleStringRepetitions = n / s.Length;
            countA *= possibleStringRepetitions;

            long offsetStringLength = n % s.Length;
            for (int i = 0; i < offsetStringLength; i++)
            {
                if (s[i] == 'a')
                    countA++;
            }
            
            return countA;
        }
    }
}
