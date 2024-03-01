namespace CardsGame
{
	internal class Program
	{
		static void Main()
		{
			List<int> hand1 = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();
			List<int> hand2 = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();

			while (hand1.Count > 0 && hand2.Count > 0)
			{
				PlayTurn(hand1, hand2);
			}
			if (hand2.Count == 0)
			{
				Console.WriteLine($"First player wins! Sum: {hand1.Sum()}");
			}
			else if (hand1.Count == 0)
			{
				Console.WriteLine($"Second player wins! Sum: {hand2.Sum()}");
			}
		}
		static void PlayTurn(List<int> hand1, List<int> hand2)
		{
			if (hand1[0] > hand2[0])
			{
				hand1.Add(hand1[0]);
				hand1.Remove(hand1[0]);
				hand1.Add(hand2[0]);
				hand2.RemoveAt(0);
			}
			else if (hand1[0] < hand2[0])
			{
				hand2.Add(hand2[0]);
				hand2.Remove(hand2[0]);
				hand2.Add(hand1[0]);
				hand1.RemoveAt(0);
			}
			else
			{
				hand1.RemoveAt(0);
				hand2.RemoveAt(0);
			}
		}
	}
}