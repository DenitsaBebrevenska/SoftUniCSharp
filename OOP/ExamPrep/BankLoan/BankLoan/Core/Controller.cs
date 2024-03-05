using BankLoan.Core.Contracts;
using BankLoan.Models.Banks;
using BankLoan.Models.Contracts;
using BankLoan.Models.Loans;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Linq;
using System.Reflection;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private IRepository<ILoan> _loans;
        private IRepository<IBank> _banks;

        public Controller()
        {
            _loans = new LoanRepository();
            _banks = new BankRepository();
        }
        public string AddBank(string bankTypeName, string name)
        {
            var children = Assembly.GetAssembly(typeof(Bank))
                .GetTypes()
                .Where(t => !t.IsAbstract && t.IsClass && (typeof(Bank)).IsAssignableTo(t))
                .Select(t => t.Name);

            if (!children.Contains(bankTypeName))
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }

            IBank model = null;

            switch (bankTypeName)
            {
                case "BranchBank":
                    model = new BranchBank(name);
                    break;
                case "CentralBank":
                    model = new CentralBank(name);
                    break;
            }

            _banks.AddModel(model);
            return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }

        public string AddLoan(string loanTypeName)
        {
            var children = Assembly.GetAssembly(typeof(Loan))
                .GetTypes()
                .Where(t => !t.IsAbstract && t.IsClass && (typeof(Loan)).IsAssignableTo(t))
                .Select(t => t.Name);

            if (!children.Contains(loanTypeName))
            {
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            }

            ILoan model = null;

            switch (loanTypeName)
            {
                case "MortgageLoan":
                    model = new MortgageLoan();
                    break;
                case "StudentLoan":
                    model = new StudentLoan();
                    break;
            }

            _loans.AddModel(model);
            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loan = null;

            switch (loanTypeName)
            {
                case "MortgageLoan":
                    loan = new MortgageLoan();
                    break;
                case "StudentLoan":
                    loan = new StudentLoan();
                    break;
            }

        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            throw new NotImplementedException();
        }

        public string FinalCalculation(string bankName)
        {
            throw new NotImplementedException();
        }

        public string Statistics()
        {
            throw new NotImplementedException();
        }
    }
}
