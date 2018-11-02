using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/ctci-ransom-note/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
    /// Easy
    /// </summary>
    
    public class RansomNote
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            var testCases = new List<Tuple<string[], string[]>>()
            {
                Tuple.Create(new string[] { "give", "me", "one", "grand", "today", "night" }, new string [] { "give", "one", "grand", "today" }),
                Tuple.Create(new string[] { "ive", "got", "a", "lovely", "bunch", "of", "coconuts" }, new string [] { "ive", "got", "some", "coconuts" })                
            };


            for (int i = 0; i < testCases.Count; i++)
            {
                Console.WriteLine("Test case {0}", i + 1);
                Console.WriteLine("Input");
                Helpers.PrintArray("    Magazine notes: ", testCases[i].Item1);
                Helpers.PrintArray("    Ransom notes: ", testCases[i].Item2);
                bool result = Play(testCases[i].Item1, testCases[i].Item2);
                Console.WriteLine("Result: {0}", result ? "Yes" : "No");
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        //public bool Play(string[] magazine, string[] note)
        //{
        //    Dictionary<string, int> availableWords = new Dictionary<string, int>();
        //    foreach (var item in magazine)
        //    {
        //        if (availableWords.ContainsKey(item))
        //            availableWords[item] += 1;
        //        else
        //            availableWords.Add(item, 1);
        //    }

        //    bool canWriteRansomNote = true;
        //    foreach (var item in note)
        //    {
        //        if (!availableWords.ContainsKey(item))
        //        {
        //            canWriteRansomNote = false;
        //            break;
        //        }

        //        availableWords[item] -= 1;

        //        if (availableWords[item] == 0)
        //            availableWords.Remove(item);
        //    }

        //    return canWriteRansomNote;

        //}

        public bool Play(string[] magazine, string[] note)
        {
            Array.Sort(magazine);
            Array.Sort(note);

            var magazineList = magazine.ToList();
                        
            bool canWriteRansomNote = true;
            foreach (var item in note)
            {   
                if (!magazineList.Remove(item))
                { 
                    canWriteRansomNote = false;
                    break;
                }                
            }

            return canWriteRansomNote;
        }
    }
}
