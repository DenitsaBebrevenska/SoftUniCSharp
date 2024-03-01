namespace DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<BaseEmployee> employees;

        public DetailsPrinter(IList<BaseEmployee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (BaseEmployee employee in employees)
            {
                Console.WriteLine(employee.GetDetails());
            }
        }

    }
}
