using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/two-strings/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
    /// Easy
    /// </summary>
    public class TwoStringsCommonSubstring
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            var testCases = new List<Tuple<string, string>>()
            {
                Tuple.Create("hello", "world"),
                Tuple.Create("hi", "world")
            };


            for (int i = 0; i < testCases.Count; i++)
            {
                Console.WriteLine("Test case {0}", i + 1);
                Console.WriteLine("Input: {0}", string.Join(" ", testCases[i].Item1, testCases[i].Item2));
                bool result = Play(testCases[i].Item1, testCases[i].Item2);
                Console.WriteLine("Result: {0}", result ? "Yes" : "No");
                Console.WriteLine();
            }

            Console.ReadKey();
        }        

        public bool Play(string s1, string s2)
        {
            foreach (var c in "abcdefghijklmnopqrstuvwxyz".ToCharArray())
            {
                if (s1.IndexOf(c) >= 0 && s2.IndexOf(c) >= 0)
                    return true;
            }

            return false;
        }
    }
}
