using System;
using System.Collections.Generic;

namespace Challenges
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/count-triplets-1/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
    /// Medium
    /// </summary>
    public class CountTriplets
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            var testCases = new List<Tuple<long[], long, Int64>>()
            {
                Tuple.Create(new long[] { 1, 2, 2, 4 }, (long)2, (Int64)2),
                Tuple.Create(new long[] { 1, 3, 9, 9, 27, 81 }, (long)3, (Int64)6),
                Tuple.Create(new long[] { 1, 5, 5, 25, 125 }, (long)5, (Int64)4),
                Tuple.Create(GenerateLargeTestCase(10), (long)1, (Int64)120),
                Tuple.Create(GenerateLargeTestCase(100), (long)1, (Int64)161700),
                Tuple.Create(GenerateLargeTestCase(1000), (long)1, (Int64)166167000),
                Tuple.Create(GenerateLargeTestCase(10000), (long)1, (Int64)166616670000),
                Tuple.Create(GenerateLargeTestCase(100000), (long)1, (Int64)166661666700000)
            };

            foreach (var tuple in testCases)
            {                
                Console.WriteLine("Input: {0}, {1}", Helpers.ArrayToString(tuple.Item1, 10), tuple.Item2);
                Int64 result = Play(new List<long>(tuple.Item1), tuple.Item2);

                var defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = result != tuple.Item3 ? ConsoleColor.Red : ConsoleColor.Green;
                Console.WriteLine("Result: {0} (Expected: {1})", result, tuple.Item3);
                Console.ForegroundColor = defaultColor;

                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private long[] GenerateLargeTestCase(int size)
        {
            long[] arr = new long[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = 1237;
            }

            return arr;
        }

        public Int64 Play(List<long> arr, long r)
        {
            // How many ways to reach each Key in 2 itterations
            Dictionary<Int64, int> pairs = new Dictionary<Int64, int>();

            // How many ways to reach each Key in 3 itterations
            Dictionary<Int64, int> triples = new Dictionary<Int64, int>();
            Int64 result = 0;

            foreach (var element in arr)
            {
                if (triples.ContainsKey(element))
                    result += triples[element];

                if (pairs.ContainsKey(element))
                {
                    // Since one element can be created in 2 itterations -> Lookahead and add potential element in the ones created by 3 itterations
                    if (triples.ContainsKey(element * r))
                        triples[element * r] += pairs[element];
                    else
                        triples[element * r] = pairs[element];
                }
                    

                // Lookahead and add potential element in the ones created by 2 itterations
                if (pairs.ContainsKey(element * r))
                    pairs[element * r] += 1;
                else
                    pairs[element * r] = 1;
            }
            
            return result;
        }
    }
}
