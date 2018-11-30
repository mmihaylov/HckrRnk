using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges
{
    public class Helpers
    {
        private static Dictionary<char, int> charPrimeNumbers = new Dictionary<char, int>
        {
            { 'a', 2 },
            { 'b', 3 },
            { 'c', 5 },
            { 'd', 7 },
            { 'e', 11 },
            { 'f', 13 },
            { 'g', 17 },
            { 'h', 19 },
            { 'i', 23 },
            { 'j', 29 },
            { 'k', 31 },
            { 'l', 37 },
            { 'm', 41 },
            { 'n', 43 },
            { 'o', 47 },
            { 'p', 53 },
            { 'q', 59 },
            { 'r', 61 },
            { 's', 67 },
            { 't', 71 },
            { 'u', 73 },
            { 'v', 79 },
            { 'w', 83 },
            { 'x', 89 },
            { 'y', 97 },
            { 'z', 101 }
        };

        public static void PrintArray<T>(T[] arr)
        {
            Helpers.PrintArray<T>(null, arr);
        }

        public static void PrintArray<T>(string prefix, T[] arr)
        {
            if (!string.IsNullOrEmpty(prefix))
                Console.Write(prefix);

            Console.WriteLine(string.Join(" ", arr));
        }

        public static string ArrayToString<T>(T[] arr)
        {
            return ArrayToString(arr, -1);
        }

        public static string ArrayToString<T>(T[] arr, int maxIndexBoundaryToPrint)
        {
            if (maxIndexBoundaryToPrint > 0)
            {
                return string.Format("[{0} ...]", string.Join(", ", arr.Take(maxIndexBoundaryToPrint)));  
            }
            else
            {
                return string.Format("[{0}]", string.Join(", ", arr));
            }
        }

        public static string ListToString<T>(List<T> list)
        {
            return string.Join(", ", list);
        }

        public static int GetCharAsPrimeNumber(char c)
        {
            return charPrimeNumbers[c];
        }
    }
}
