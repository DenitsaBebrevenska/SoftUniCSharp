namespace CopyDirectory
{
    using System;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            DirectoryInfo inputDirectory = new DirectoryInfo(inputPath);
            FileInfo[] files = inputDirectory.GetFiles();
            DirectoryInfo outputDirectory = new DirectoryInfo(outputPath);

            if (outputDirectory.Exists)
            {
                outputDirectory.Delete(true);
            }

            Directory.CreateDirectory(outputDirectory.FullName);

            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(outputDirectory.FullName, file.Name));
            }
        }
    }
}