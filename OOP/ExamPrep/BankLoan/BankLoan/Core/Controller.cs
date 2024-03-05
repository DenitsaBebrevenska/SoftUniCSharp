using BankLoan.Core.Contracts;
using BankLoan.Models.Banks;
using BankLoan.Models.Clients;
using BankLoan.Models.Contracts;
using BankLoan.Models.Loans;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

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
                .Where(t => !t.IsAbstract && t.IsClass && (typeof(Bank)).IsAssignableFrom(t))
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
                .Where(t => !t.IsAbstract && t.IsClass && (typeof(Loan)).IsAssignableFrom(t))
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
            ILoan loan = _loans.Models.FirstOrDefault(m => m.GetType().Name == loanTypeName);

            if (loan == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }

            _loans.RemoveModel(loan);
            IBank bank = _banks.FirstModel(bankName);
            bank.AddLoan(loan);
            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            var children = Assembly.GetAssembly(typeof(Client))
                .GetTypes()
                .Where(t => !t.IsAbstract && t.IsClass && (typeof(Client)).IsAssignableFrom(t))
                .Select(t => t.Name);

            if (!children.Contains(clientTypeName))
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }

            IBank bank = _banks.FirstModel(bankName);

            if ((bank.GetType().Name == "BranchBank" && clientTypeName != "Student")
                || (bank.GetType().Name == "CentralBank" && clientTypeName != "Adult"))
            {
                return OutputMessages.UnsuitableBank;
            }

            IClient client = null;

            switch (clientTypeName)
            {
                case "Student":
                    client = new Student(clientName, id, income);
                    break;
                case "Adult":
                    client = new Adult(clientName, id, income);
                    break;
            }

            bank.AddClient(client);

            return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
        }

        public string FinalCalculation(string bankName)
        {
            IBank bank = _banks.FirstModel(bankName);
            double funds = bank.Clients.Sum(c => c.Income) + bank.Loans.Sum(l => l.Amount);
            return $"The funds of bank {bankName} are {funds:F2}.";
        }

        public string Statistics()
        {
            StringBuilder statistics = new StringBuilder();

            foreach (var bank in _banks.Models)
            {
                statistics.AppendLine(bank.GetStatistics());
            }

            return statistics.ToString().TrimEnd();
        }
    }
}
