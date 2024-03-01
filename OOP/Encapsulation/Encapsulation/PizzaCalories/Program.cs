namespace PizzaCalories
{
    public class Program
    {
        static void Main()
        {
            string[] pizzaTokens = Console.ReadLine().Split(' '); //removed string split options because the name of the pizza can`t be set to empty string as it should be tested
            string[] doughTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                Pizza pizza = new Pizza(pizzaTokens[1], new Dough(doughTokens[1],
                    doughTokens[2], int.Parse(doughTokens[3])));

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    pizza.AddTopping(new Topping(toppingTokens[1], int.Parse(toppingTokens[2])));
                }

                Console.WriteLine(pizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
