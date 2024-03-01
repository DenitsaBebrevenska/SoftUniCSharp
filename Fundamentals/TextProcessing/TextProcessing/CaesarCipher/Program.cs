using System.Text;

namespace CaesarCipher
{
	internal class Program
	{
		static void Main()
		{
			string message = Console.ReadLine();
			StringBuilder sb = new StringBuilder();

			foreach (char c in message)
			{
				int encryptedChar = c + 3;
				sb.Append((char)encryptedChar);
			}

			Console.WriteLine(sb);
		}
	}
}