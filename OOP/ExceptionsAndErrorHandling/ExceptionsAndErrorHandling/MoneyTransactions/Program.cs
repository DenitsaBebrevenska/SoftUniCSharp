namespace MoneyTransactions
{
    public class Program
    {
        static void Main()
        {
            Dictionary<string, double> availableAccounts = new();
            string[] accounts = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (string account in accounts)
            {
                string[] accountDetails = account.Split('-', StringSplitOptions.RemoveEmptyEntries);
                availableAccounts.Add(accountDetails[0], double.Parse(accountDetails[1]));
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = commandTokens[0];
                string number = commandTokens[1];
                double amount = double.Parse(commandTokens[2]);

                try
                {
                    string currentAccount = availableAccounts.FirstOrDefault(a => a.Key == number).Key;

                    if (currentAccount == null)
                    {
                        throw new Exception("Invalid account!");
                    }

                    if (action == "Deposit")
                    {
                        availableAccounts[number] += amount;
                    }
                    else if (action == "Withdraw")
                    {
                        if (amount > availableAccounts[number])
                        {
                            throw new Exception("Insufficient balance!");
                        }

                        availableAccounts[number] -= amount;
                    }
                    else
                    {
                        throw new Exception("Invalid command!");
                    }

                    Console.WriteLine($"Account {number} has new balance: {availableAccounts[number]:F2}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }

}
