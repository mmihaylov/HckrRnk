using System;

namespace Challenges
{
    public class Helpers
    {
        public static void PrintArray<T>(T[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
