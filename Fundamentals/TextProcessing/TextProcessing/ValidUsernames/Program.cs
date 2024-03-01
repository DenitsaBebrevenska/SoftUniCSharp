namespace ValidUsernames
{
	internal class Program
	{
		static void Main()
		{
			string[] usernameList = Console.ReadLine().Split(", ");

			foreach (string username in usernameList.Where(s => s.Length >= 3 && s.Length <= 16
			         && !s.Any(c => !char.IsLetterOrDigit(c) && c != '-' && c != '_')))
			{
				Console.WriteLine(username);
			}
		}
	}
}