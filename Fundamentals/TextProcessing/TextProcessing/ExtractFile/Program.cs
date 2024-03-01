namespace ExtractFile
{
	internal class Program
	{
		static void Main()
		{
			string path = Console.ReadLine();
			int lastSlash = path.LastIndexOf('\\');
			int lastPeriod = path.LastIndexOf('.');
			int length = lastPeriod - lastSlash;
			string fileName = path.Substring(lastSlash + 1, length - 1);
			string fileExtension = path.Substring(lastPeriod + 1);

			Console.WriteLine($"File name: {fileName}");
			Console.WriteLine($"File extension: {fileExtension}");
		}
	}
}