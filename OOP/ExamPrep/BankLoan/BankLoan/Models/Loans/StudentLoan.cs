﻿namespace BankLoan.Models.Loans
{
    public class StudentLoan : Loan
    {
        private const int StudentLoanInterestRate = 1;
        private const double StudentLoanAmount = 10_000;
        public StudentLoan()
            : base(StudentLoanInterestRate, StudentLoanAmount)
        {
        }
    }
}
