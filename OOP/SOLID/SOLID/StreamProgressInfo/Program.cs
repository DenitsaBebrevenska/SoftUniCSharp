namespace StreamProgressInfo
{
    public class Program
    {
        static void Main()
        {
            IStreamable streamableFile = new File("New", 10, 20);
            IStreamable streamableMusic = new Music("Rammstein", "Deutchland", 300, 750);
            StreamProgressInfo spFile = new StreamProgressInfo(streamableFile);
            Console.WriteLine(spFile.CalculateCurrentPercent());
            StreamProgressInfo spMusic = new StreamProgressInfo(streamableMusic);
            Console.WriteLine(spMusic.CalculateCurrentPercent());
        }
    }
}
