namespace BankLoan.Models.Clients
{
    public class Student : Client
    {
        private const int StudentInitialInterest = 2;
        public Student(string name, string id, double income)
            : base(name, id, StudentInitialInterest, income)
        {
        }

        public override void IncreaseInterest() => Interest++;
    }
}
