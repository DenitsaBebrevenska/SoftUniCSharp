using System.Text.RegularExpressions;
namespace FancyBarcodes
{
	internal class Program
	{
		static void Main()
		{
			int numberOfBarcodes = int.Parse(Console.ReadLine());
			string barcodeFilter = @"(@#+)(?<barcode>[A-Z][A-Za-z\d]{4,}[A-Z])(@#+)";
			
			for (int i = 0; i < numberOfBarcodes; i++)
			{
				string barcode = Console.ReadLine();
				Match match = Regex.Match(barcode, barcodeFilter);
				if (!match.Success)
				{
					Console.WriteLine("Invalid barcode");
					continue;
				}

				barcode = match.Groups["barcode"].Value;
				
				MatchCollection digits = Regex.Matches(barcode, @"\d");
				if (digits.Count == 0)
				{
					Console.WriteLine("Product group: 00");
					continue;
				}

				string productGroup = string.Empty;
				foreach (Match matchDigit in digits)
				{
					productGroup += matchDigit.Value;
				}
				Console.WriteLine($"Product group: {productGroup}");
			}
		}
	}
}