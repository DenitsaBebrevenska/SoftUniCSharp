namespace TheaThePhotographer
{
	internal class Program
	{
		static void Main()
		{
			long photosTaken = long.Parse(Console.ReadLine());
			long filterTimeSeconds = long.Parse(Console.ReadLine());
			int percentageGoodPhotos = int.Parse(Console.ReadLine());
			long uploadTimeSeconds = long.Parse(Console.ReadLine());

			long totalFilterTime = photosTaken * filterTimeSeconds;
			double photosFoundGood = Math.Ceiling(photosTaken * (percentageGoodPhotos * 0.01));
			long totalTimeUpload = (long)photosFoundGood * uploadTimeSeconds;
			long totalTimeAll = totalFilterTime + totalTimeUpload; //in seconds

			long days = totalTimeAll / (24 * 3600); 
      
			totalTimeAll %= (24 * 3600); 
			long hours = totalTimeAll / 3600; 
      
			totalTimeAll %= 3600; 
			long minutes = totalTimeAll / 60 ; 
      
			totalTimeAll %= 60; 
			long seconds = totalTimeAll; 

			Console.WriteLine($"{days}:{hours:D2}:{minutes:D2}:{seconds:D2}");
		}
	}
}