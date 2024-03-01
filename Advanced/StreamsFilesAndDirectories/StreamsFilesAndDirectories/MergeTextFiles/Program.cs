namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            List<string> text1 = new List<string>();
            List<string> text2 = new List<string>();

            using (StreamReader reader = new StreamReader(firstInputFilePath))
            {
                while (!reader.EndOfStream)
                {
                    text1.Add(reader.ReadLine());
                }
            }

            using (StreamReader reader = new StreamReader(secondInputFilePath))
            {
                while (!reader.EndOfStream)
                {
                    text2.Add(reader.ReadLine());
                }
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                while (text1.Count > 0 && text2.Count > 0)
                {
                    writer.WriteLine(text1[0]);
                    writer.WriteLine(text2[0]);

                    text1.RemoveAt(0);
                    text2.RemoveAt(0);
                }

                List<string> leftLines = text1.Count > 0 ? text1 : text2;

                for (int i = 0; i < leftLines.Count; i++)
                {
                    writer.WriteLine(leftLines[i]);
                }
            }
        }
    }
}