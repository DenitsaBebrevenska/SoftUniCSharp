namespace Recharge
{
    public class StartUp
    {
        static void Main()
        {
            Worker employee = new Employee("20");
            Worker robot = new Robot("10", 100);
            List<Worker> workers = new List<Worker>();

            foreach (var worker in workers)
            {
                worker.Work(10);
            }

            ISleeper sleeper = (ISleeper)employee;
            sleeper.Sleep();
            IRechargeable rechargeable = (IRechargeable)robot;
            rechargeable.Recharge();
        }
    }
}
