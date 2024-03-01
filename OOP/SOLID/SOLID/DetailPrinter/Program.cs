namespace DetailPrinter
{
    public class Program
    {
        static void Main()
        {
            Employee employee = new Employee("Marc");
            Employee employee2 = new Employee("Tom");
            List<string> managerDocuments = new List<string>()
            {
                "some fancy documents",
                "some not so fancy documents",
                "CVs",
                "contracts"
            };

            Manager manager = new Manager("August", managerDocuments);
            List<BaseEmployee> employees = new List<BaseEmployee>()
            {
                employee,
                employee2,
                manager
            };

            DetailsPrinter dp = new DetailsPrinter(employees);
            dp.PrintDetails();
        }
    }
}
