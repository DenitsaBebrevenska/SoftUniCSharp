namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFilePath = @"../../../copyMe.png";
            string zipArchiveFilePath = @"../../../archive.zip";
            string fileName = "extracted.png";
            string outputFilePath = @"../../..";
            ZipFileToArchive(inputFilePath, zipArchiveFilePath);
            ExtractFileFromArchive(zipArchiveFilePath, fileName, outputFilePath);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            using ZipArchive zip = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create);
            zip.CreateEntryFromFile(inputFilePath, "copyMe.png");
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
           using ZipArchive zip = ZipFile.OpenRead(zipArchiveFilePath);
           foreach (var entry in zip.Entries)
           {
               entry.ExtractToFile(Path.Combine(outputFilePath, fileName));
           }

        }
    }
}