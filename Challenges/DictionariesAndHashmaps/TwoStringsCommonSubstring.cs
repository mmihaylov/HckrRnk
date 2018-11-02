using System;
using System.Collections.Generic;

namespace Challenges
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/sherlock-and-anagrams/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
    /// Medium
    /// </summary>
    public class SherlockAndAnagrams
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            var testCases = new Dictionary<string, int>()
            {
                { "abba", 4 },
                { "abcd", 0 },
                { "ifailuhkqq", 3 },
                { "kkkk", 10 },
                { "cdcd", 5 },
                { "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 166650 },
                { "bbcaadacaacbdddcdbddaddabcccdaaadcadcbddadababdaaabcccdcdaacadcababbabbdbacabbdcbbbbbddacdbbcdddbaaa", 4832 },
                { "cacccbbcaaccbaacbbbcaaaababcacbbababbaacabccccaaaacbcababcbaaaaaacbacbccabcabbaaacabccbabccabbabcbba", 13022 },
                { "bbcbacaabacacaaacbbcaabccacbaaaabbcaaaaaaaccaccabcacabbbbabbbbacaaccbabbccccaacccccabcabaacaabbcbaca", 9644 },
                { "cbaacdbaadbabbdbbaabddbdabbbccbdaccdbbdacdcabdbacbcadbbbbacbdabddcaccbbacbcadcdcabaabdbaacdccbbabbbc", 6346 },
                { "babacaccaaabaaaaaaaccaaaccaaccabcbbbabccbbabababccaabcccacccaaabaccbccccbaacbcaacbcaaaaaaabacbcbbbcc", 8640 },
                { "bcbabbaccacbacaacbbaccbcbccbaaaabbbcaccaacaccbabcbabccacbaabbaaaabbbcbbbbbaababacacbcaabbcbcbcabbaba", 11577 },
            };

            foreach (string key in testCases.Keys)
            {                
                Console.WriteLine("Input: {0}", key);
                int result = Play(key);
                Console.WriteLine("Result: {0} (Expected: {1})", result, testCases[key]);
                Console.WriteLine();
            }

            Console.ReadKey();
        }        

        public int Play(string s)
        {
            Dictionary<string, int> anagramsCount = new Dictionary<string, int>();
            int anagramPairs = 0;

            for (int i = 1; i < s.Length; i++)
            {
                for (int startIndex = 0; startIndex <= s.Length - i; startIndex++)
                {
                    char[] chars = s.Substring(startIndex, i).ToCharArray();
                    Array.Sort(chars);
                    string sortedSubstring = new string(chars);

                    if (anagramsCount.ContainsKey(sortedSubstring))
                    {
                        anagramPairs += anagramsCount[sortedSubstring];
                        anagramsCount[sortedSubstring] += 1;
                    }
                    else
                        anagramsCount[sortedSubstring] = 1;
                }
            }            

            return anagramPairs;
        }
    }
}
