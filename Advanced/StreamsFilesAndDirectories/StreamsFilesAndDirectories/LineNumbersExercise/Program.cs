using System.Text.RegularExpressions;

namespace LineNumbersExercise
{
    internal class Program
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }
        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] linesOfText = File.ReadAllLines(inputFilePath);

            for (int i = 1; i <= linesOfText.Length; i++)
            {
                MatchCollection matchLetters = Regex.Matches(linesOfText[i - 1], "[A-Za-z]");
                MatchCollection matchPunctuation = Regex.Matches(linesOfText[i - 1], @"\p{P}");
                linesOfText[i - 1] = $"Line {i}: {linesOfText[i - 1]} ({matchLetters.Count})({matchPunctuation.Count})";
            }

            File.WriteAllLines(outputFilePath, linesOfText);
        }
    }
}
