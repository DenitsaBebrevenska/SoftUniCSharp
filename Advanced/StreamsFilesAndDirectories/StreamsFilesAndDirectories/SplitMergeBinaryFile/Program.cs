namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            List<byte>bytes = File.ReadAllBytes(sourceFilePath).ToList();
            List<byte> bytesFirstFile = new List<byte>();

            if (bytes.Count % 2 == 0)
            {
                bytesFirstFile.AddRange(bytes.Take(bytes.Count/2));
                bytes.RemoveRange(0, bytes.Count/2);
            }
            else
            {
                bytesFirstFile.AddRange(bytes.Take(bytes.Count/2 + 1));
                bytes.RemoveRange(0, bytes.Count/2 + 1);
            }

            File.WriteAllBytes(partOneFilePath, bytesFirstFile.ToArray());
            File.WriteAllBytes(partTwoFilePath, bytes.ToArray());
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            List<byte> bytes = File.ReadAllBytes(partOneFilePath).ToList();
            bytes.AddRange(File.ReadAllBytes(partTwoFilePath));
            File.WriteAllBytes(joinedFilePath, bytes.ToArray());
        }
    }
}