using System.Text;
using System.Text.RegularExpressions;

namespace EvenLines
{
    using System;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder processedLines = new ();
            int lineCount = 0;

            using (StreamReader streamReader = new (inputFilePath))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();

                    if (lineCount % 2 == 0)
                    {
                        line = Regex.Replace(line, @"[-,.!?]", "@");
                        line = string.Join(" ", line.Split().Reverse().ToArray());
                        processedLines.AppendLine(line);
                    }

                    lineCount++;
                }
            }

            return processedLines.ToString();
        }
    }
}