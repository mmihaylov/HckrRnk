using System;
using System.Collections.Generic;

namespace Challenges
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/frequency-queries/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
    /// Medium
    /// </summary>
    public class FrequencyQueries
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            var testCases = new List<Tuple<List<List<int>>, List<int>>>()
            {
                Tuple.Create(new List<List<int>> {
                                            new List<int> { 1, 1 },
                                            new List<int> { 2, 2 },
                                            new List<int> { 3, 2 },
                                            new List<int> { 1, 1 },
                                            new List<int> { 1, 1 },
                                            new List<int> { 2, 1 },
                                            new List<int> { 3, 2 }
                                            }, 
                               new List<int> { 0, 1}),
                Tuple.Create(new List<List<int>> {
                                            new List<int> { 1, 5 },
                                            new List<int> { 2, 6 },
                                            new List<int> { 3, 2 },
                                            new List<int> { 1, 10 },
                                            new List<int> { 1, 10 },
                                            new List<int> { 1, 6 },
                                            new List<int> { 2, 5 },
                                            new List<int> { 3, 2 }
                                            },
                               new List<int> { 0, 1}),
                Tuple.Create(new List<List<int>> {
                                            new List<int> { 3, 4 },
                                            new List<int> { 2, 1003 },
                                            new List<int> { 1, 16 },
                                            new List<int> { 3, 1 }
                                            },
                               new List<int> { 0, 1}),
                Tuple.Create(new List<List<int>> {
                                            new List<int> { 1, 3 },
                                            new List<int> { 2, 3 },
                                            new List<int> { 3, 2 },
                                            new List<int> { 1, 4 },
                                            new List<int> { 1, 5 },
                                            new List<int> { 1, 5 },
                                            new List<int> { 1, 4 },
                                            new List<int> { 3, 2 },
                                            new List<int> { 2, 4 },
                                            new List<int> { 3, 2 },
                                            },
                               new List<int> { 0, 1, 1}),
            };

            foreach (var tuple in testCases)
            {
                List<int> result = Play(tuple.Item1);
                var defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = Helpers.ListToString<int>(result) != Helpers.ListToString(tuple.Item2) ? ConsoleColor.Red : ConsoleColor.Green;
                Console.WriteLine("Result: {0} (Expected: {1})", Helpers.ListToString<int>(result), Helpers.ListToString(tuple.Item2));
                Console.ForegroundColor = defaultColor;
            }

            Console.ReadLine();
        }        

        public List<int> Play(List<List<int>> queries)
        {
            var result = new List<int>();
            var items = new Dictionary<int, int>();
            var frequencies = new Dictionary<int, int>();
            
            foreach (var query in queries)
            {
                if (query[0] == 1)
                {
                    int itemToAdd = query[1];
                    if (items.ContainsKey(itemToAdd))
                    {                        
                        items[itemToAdd] += 1;
                    }
                    else
                    {
                        items[itemToAdd] = 1;
                    }

                    var frequencetyToAdd = items[itemToAdd];
                    
                    // Add the new frequency
                    if (frequencies.ContainsKey(frequencetyToAdd))
                        frequencies[frequencetyToAdd] += 1;
                    else
                        frequencies[frequencetyToAdd] = 1;

                    // Remove the old new frequency
                    if (frequencetyToAdd > 1 && frequencies.ContainsKey(frequencetyToAdd - 1))
                    {
                        frequencies[frequencetyToAdd - 1] -= 1;
                    }                    
                }
                else if (query[0] == 2)
                {
                    int itemToRemove = query[1];
                    if (items.ContainsKey(itemToRemove) && items[itemToRemove] > 0)
                    {
                        items[itemToRemove] -= 1;

                        var frequencyToRemove = items[itemToRemove];

                        // Remove the old frequency
                        if (frequencies.ContainsKey(frequencyToRemove + 1))
                        {
                            frequencies[frequencyToRemove + 1] -= 1;
                        }

                        // Add the new frequency
                        if (frequencyToRemove > 0)
                        {
                            if (frequencies.ContainsKey(frequencyToRemove))
                                frequencies[frequencyToRemove] += 1;
                            else
                                frequencies[frequencyToRemove] = 1;
                        }
                    }
                                     
                }
                else if (query[0] == 3)
                {                    
                    result.Add(frequencies.ContainsKey(query[1]) && frequencies[query[1]] > 0 ? 1 : 0);
                }
            }

            return result;
        }
    }
}
