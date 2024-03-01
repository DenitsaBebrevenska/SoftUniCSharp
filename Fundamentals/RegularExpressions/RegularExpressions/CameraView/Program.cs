using System.Text.RegularExpressions;

namespace CameraView
{
	internal class Program
	{
		static void Main()
		{
			string[] numbers = Console.ReadLine().Split();
			string cameras = Console.ReadLine();
			string skip = numbers[0];
			string take = numbers[1];
			string pattern = @"\|<\w{" + skip + @"}(?<camera>\w{0," + take + "})";
			
			MatchCollection matches = Regex.Matches(cameras, pattern);
			List<string> cameraList = new List<string>();

			foreach (Match match in matches)
			{
				cameraList.Add(match.Groups["camera"].Value);
			}

			Console.WriteLine(string.Join(", ", cameraList));
		}
	}
}
