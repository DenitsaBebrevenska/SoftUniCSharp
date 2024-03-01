using System.IO;

namespace BonusSplitFilesNParts
{
    internal class Program
    {
        static readonly string PathInput = "../../../input.txt";
        static void Main()
        {
            
            Console.WriteLine("How many parts do you want to split the input.txt file into?");
            byte[] fileBytes = File.ReadAllBytes(PathInput);
            int partsCount = GetCorrectCountFromUser(fileBytes.Length);
            SplitFileIntoNParts(fileBytes, partsCount);
        }

        static void SplitFileIntoNParts(byte[] fileBytes, int partsCount)
        {
            int parts = fileBytes.Length / partsCount;
            using (FileStream fileOpen = new FileStream(PathInput, FileMode.Open))
            {
                int offset = 0;

                for (int i = 1; i <= partsCount; i++)
                {
                    fileOpen.Read(fileBytes, offset, parts);

                    using (FileStream fileCreate = new FileStream($"../../../output{i}.txt", FileMode.Create))
                    {
                        fileCreate.Write(fileBytes, offset, parts);
                    }

                    offset += parts;
                }
            }
        }

        static int GetCorrectCountFromUser(long fileLength)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    if (result < 0)
                    {
                        Console.WriteLine("The parts count cannot be a negative number! Enter a new count!");
                        continue;
                    }

                    if (result > fileLength)
                    {
                        Console.WriteLine("Cannot split file into more parts than its length! Enter a new count!");
                        continue;
                    }

                    return result;
                }

                Console.WriteLine("Invalid input! Please enter a number!");

            }
        }
    }
}
