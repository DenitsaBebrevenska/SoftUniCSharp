using System.Text;

namespace DirectoryTraversal
{
    using System;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(inputFolderPath);
            FileInfo[] files = directoryInfo.GetFiles();

            Dictionary<string, List<FileInfo>> fileDictionary = new Dictionary<string, List<FileInfo>>();

            foreach (FileInfo file in files)
            {
                if (!fileDictionary.ContainsKey(file.Extension))
                {
                    fileDictionary.Add(file.Extension, new List<FileInfo>());
                }

                fileDictionary[file.Extension].Add(file);
            }

            StringBuilder reportBuilder = new();
            CreateReport(fileDictionary, reportBuilder);
            return reportBuilder.ToString();
        }

        public static void CreateReport(Dictionary<string, List<FileInfo>> fileDictionary, StringBuilder reportBuilder)
        {
            foreach (var kvp in fileDictionary.OrderByDescending(e => e.Value.Count).ThenBy(e => e.Key))
            {
                reportBuilder.AppendLine(kvp.Key);

                foreach (FileInfo file in kvp.Value.OrderBy(f => f.Length))
                {
                    reportBuilder.AppendLine($"--{file.Name} - {(double)file.Length / 1024}kb");
                }
            }
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(Path.Combine(desktopPath, reportFileName), textContent);
        }
    }
}