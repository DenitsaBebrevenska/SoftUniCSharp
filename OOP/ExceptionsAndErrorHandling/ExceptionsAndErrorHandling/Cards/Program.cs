namespace Cards
{
    public class Program
    {
        static void Main()
        {
            string[] cards = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<Card> validCards = new();

            foreach (string card in cards)
            {
                string[] cardDetails = card.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    validCards.Add(new Card(cardDetails[0], cardDetails[1]));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(' ', validCards));
        }
    }
}
