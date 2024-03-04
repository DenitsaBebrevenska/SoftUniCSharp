namespace BankLoan.Models.Clients
{
    public class Adult : Client
    {
        private const int AdultInitialInterest = 4;
        public Adult(string name, string id, double income)
            : base(name, id, AdultInitialInterest, income)
        {
        }

        public override void IncreaseInterest() => Interest += 2;
    }
}
