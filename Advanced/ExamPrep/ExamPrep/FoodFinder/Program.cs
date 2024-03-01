using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    internal class Program
    {
        static void Main()
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse));
            Stack<char> consonants = new Stack<char>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse));
            Dictionary<string, HashSet<char>> wordsCharOccurrence = new Dictionary<string, HashSet<char>>()
            {
                {"pear",new HashSet<char>()},
                {"flour", new HashSet<char>()},
                {"pork", new HashSet<char>()},
                {"olive", new HashSet<char>()}
            };

            while (consonants.Count > 0)
            {
                char currentVowel = vowels.Dequeue();
                char currentConsonant = consonants.Pop();

                foreach (var kvp in wordsCharOccurrence)
                {
                    if (kvp.Key.Contains(currentVowel))
                    {
                        kvp.Value.Add(currentVowel);
                    }

                    if (kvp.Key.Contains(currentConsonant))
                    {
                        kvp.Value.Add(currentConsonant);
                    }
                }

                vowels.Enqueue(currentVowel);
            }

            int wordCount = wordsCharOccurrence.Count(w => w.Key.Length == w.Value.Count);
            Console.WriteLine($"Words found: {wordCount}");

            foreach (var kvp in wordsCharOccurrence
                         .Where(w => w.Key.Length == w.Value.Count))
            {
                Console.WriteLine(kvp.Key);
            }
        }
    }
}
