using System.Text.RegularExpressions;

namespace ExtractSpecialBytes
{
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\example.png";
            string bytesFilePath = @"..\..\..\bytes.txt";
            string outputPath = @"..\..\..\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            byte[] bytesFromImage = File.ReadAllBytes(binaryFilePath);
            string bytesText = File.ReadAllText(bytesFilePath);
            MatchCollection matchText = Regex.Matches(bytesText, "[0-9]+");

            List<byte> bytesToExtract = new List<byte>();
            foreach (Match match in matchText)
            {
                bytesToExtract.Add(byte.Parse(match.ToString()));
            }

            List<byte> commonBytes = new List<byte>();

            for (int i = 0; i < bytesFromImage.Length; i++)
            {
                if (bytesToExtract.Contains(bytesFromImage[i]))
                {
                    commonBytes.Add(bytesFromImage[i]);
                }
            }

            using (FileStream fileStream = new FileStream(outputPath, FileMode.Create))
            {
                fileStream.Write(commonBytes.ToArray());
            }
        }
    }
}