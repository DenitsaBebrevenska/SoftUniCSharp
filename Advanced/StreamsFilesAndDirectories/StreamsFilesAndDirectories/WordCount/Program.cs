using System.Text.RegularExpressions;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            List<string> words = new List<string>();
            Dictionary<string, int> wordOccurrence = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader(wordsFilePath))
            {
                words = reader.ReadToEnd().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            using (StreamReader reader = new StreamReader(textFilePath))
            {
                string input = reader.ReadToEnd();
                MatchCollection matches = Regex.Matches(input, "[a-zA-z]+");

                foreach (var match in matches)
                {
                    string word = match.ToString().ToLower();

                    if (words.Contains(word))
                    {
                        if (!wordOccurrence.ContainsKey(word))
                        {
                            wordOccurrence.Add(word, 1);
                            continue;
                        }

                        wordOccurrence[word]++;
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var kvp in wordOccurrence.OrderByDescending(w => w.Value))
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}