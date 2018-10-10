using System;
using System.Collections.Generic;

namespace Challenges
{
    public class CountingValleys
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            var testCases = new List<Tuple<int, string>>()
            {
                Tuple.Create(8, "UDDDUDUU"),
                Tuple.Create(12, "DDUUDDUDUUUD")
            };

            for (int i = 0; i < testCases.Count; i++)
            {
                Console.WriteLine("Test case {0}", i + 1);
                Console.WriteLine("Input: {0}", string.Join(" ", testCases[i].Item1, testCases[i].Item2));
                int result = Play(testCases[i].Item1, testCases[i].Item2);
                Console.WriteLine("Result: {0}{1}", result, Environment.NewLine);
            }

            Console.ReadLine();
        }        

        public int Play(int n, string s)
        {
            var seaLevel = 0;
            var valleyCount = 0;
            var isValleyActive = false;

            for (int i = 0; i < n; i++)
            {
                if (s[i] == 'U')
                {
                    seaLevel++;
                }
                else
                {
                    seaLevel--;
                }

                if (!isValleyActive && seaLevel < 0)
                {
                    isValleyActive = true;
                }

                if (isValleyActive && seaLevel == 0)
                {
                    valleyCount++;
                    isValleyActive = false;
                }
            }

            return valleyCount;
        }
    }
}
