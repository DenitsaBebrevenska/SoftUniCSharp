namespace BankLoan.Models.Banks
{
    public class BranchBank : Bank
    {
        private const int BranchBandCapacity = 25;
        public BranchBank(string name)
            : base(name, BranchBandCapacity)
        {
        }
    }
}
