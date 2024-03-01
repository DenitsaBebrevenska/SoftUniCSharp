namespace TheVLogger
{
    internal class Program
    {
        static void Main()
        {
            string input;
            List<Vlogger> vloggerList = new List<Vlogger>();

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] entryArgs = input.Split();
                string name = entryArgs[0];

                if (input.Contains("joined"))
                {
                   HandleMemberJoining(vloggerList, name);
                }
                else //contains "followed"
                {
                    string vloggerFollowed = entryArgs[2];
                    HandleFollowingEvent(vloggerList, name, vloggerFollowed);
                }
            }

            PrintVloggerList(vloggerList);
        }

        static void HandleMemberJoining(List<Vlogger> vloggerList, string name)
        {
            Vlogger vlogger = vloggerList.FirstOrDefault(v => v.Name == name);

            if (vlogger == null)
            {
                vloggerList.Add(new Vlogger()
                {
                    Name = name
                });
            }
        }

        static void HandleFollowingEvent(List<Vlogger> vloggerList, string name, string vloggerFollowed)
        {
            Vlogger vlogger = vloggerList.FirstOrDefault(v => v.Name == vloggerFollowed);
            Vlogger follower = vloggerList.FirstOrDefault(v => v.Name == name);

            if (name == vloggerFollowed || vlogger == null || follower == null)
            {
                return;
            }

            if (vlogger.Followers.Contains(name))
            {
                return;
            }

            vlogger.Followers.Add(name);
            follower.FollowingCount++;
        }

        static void PrintVloggerList(List<Vlogger> vloggerList)
        {
            Console.WriteLine($"The V-Logger has a total of {vloggerList.Count} vloggers in its logs.");

            int counter = 0;

            foreach (Vlogger vlogger in vloggerList.OrderByDescending(v => v.Followers.Count).ThenBy(v => v.FollowingCount))
            {
                counter++;
                if (counter == 1)
                {
                    Console.WriteLine($"{counter}. {vlogger}");
                    vlogger.PrintFollowerList();
                    continue;
                }

                Console.WriteLine($"{counter}. {vlogger}");
            }
        }
    }
}
