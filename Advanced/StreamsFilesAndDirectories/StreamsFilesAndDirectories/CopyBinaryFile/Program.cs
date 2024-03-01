namespace CopyBinaryFile
{
    using System;

    public class CopyBinaryFile
    {
        //Write a program that copies the contents of a binary file (e. g. copyMe.png) to another binary file (e. g. copyMe-copy.png) using FileStream. You are not allowed to use the File class or similar helper classes.
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream fileOpen = new FileStream(inputFilePath, FileMode.Open))
            {
                using (FileStream fileCreate = new FileStream(outputFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096]; //A buffer size most often used according to StackOverflow

                    while (true)
                    {
                        int bytesRead = fileOpen.Read(buffer);

                        if (bytesRead == 0)
                        {
                            break;
                        }

                        fileCreate.Write(buffer, 0, bytesRead);
                    }

                }
            }
        }
    }
}