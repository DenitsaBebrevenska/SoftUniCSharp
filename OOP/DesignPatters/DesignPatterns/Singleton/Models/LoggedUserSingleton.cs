namespace Singleton
{
    public class LoggedUserSingleton
    {
        private static LoggedUserSingleton instance;
        private static object lockObject = new object();

        private LoggedUserSingleton()
        {
            Console.WriteLine("Logged user created.");
        }

        public string Name { get; set; }

        public static LoggedUserSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject) //thread safe
                    {
                        if (instance == null)
                        {
                            instance = new LoggedUserSingleton();
                        }
                    }
                }

                return instance;
            }
        }
    }
}
