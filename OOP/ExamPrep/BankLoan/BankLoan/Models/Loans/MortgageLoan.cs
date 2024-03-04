﻿namespace BankLoan.Models.Loans
{
    public class MortgageLoan : Loan
    {
        private const int MortgageLoanInterestRate = 3;
        private const double MortgageLoanAmount = 50_000;
        public MortgageLoan()
            : base(MortgageLoanInterestRate, MortgageLoanAmount)
        {
        }
    }
}
