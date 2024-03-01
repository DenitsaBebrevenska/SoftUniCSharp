namespace PhotoGallery
{
	internal class Program
	{
		static void Main()
		{
			int photoNumber = int.Parse(Console.ReadLine());
			int day	= int.Parse(Console.ReadLine());
			int month = int.Parse(Console.ReadLine());
			int year = int.Parse(Console.ReadLine());
			byte hour = byte.Parse(Console.ReadLine());
			byte minute = byte.Parse(Console.ReadLine());
			int photoSize = int.Parse(Console.ReadLine());
			int widthPhoto = int.Parse(Console.ReadLine());
			int heightPhoto = int.Parse(Console.ReadLine());
			

			string orientation  = GetOrientation(widthPhoto, heightPhoto);
			
			string size = GetSize(photoSize);
			

			Console.WriteLine($"Name: DSC_{photoNumber:D4}.jpg");
			Console.WriteLine($"Date Taken: {day:D2}/{month:D2}/{year} {hour:D2}:{minute:D2}");
			Console.WriteLine($"Size: {size}");
			Console.WriteLine($"Resolution: {widthPhoto}x{heightPhoto} ({orientation})");
		}

		static string GetOrientation(int widthPhoto, int heightPhoto)
		{
			if (heightPhoto == widthPhoto)
			{
				return "square";
			}
			else if (heightPhoto > widthPhoto)
			{
				return "portrait";
			}
			else
			{
				return "landscape";
			}
		}

		static string GetSize(int photoSize) //up to MB, no more
		{
			if (photoSize < 1000)
			{
				return $"{photoSize}B";
			}
			else if (photoSize < 1000 * 1000)
			{
				double sizeKB = Math.Round(((double)photoSize / 1000),1);
				return $"{sizeKB}KB";
			}
			else
			{
				double sizeMB = Math.Round(((double)photoSize / (1000 * 1000)), 1);
				return $"{sizeMB}MB";
			}
		}
	}
}