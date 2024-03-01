using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVLogger
{
    internal class Vlogger
    {
        public string Name { get; set; }

        public int FollowingCount { get; set; }

        public List<string> Followers { get; set; }

        public Vlogger()
        {
            Followers = new List<string>();
        }

        public override string ToString()
        {
            return $"{Name} : {Followers.Count} followers, {FollowingCount} following";
        }

        public void PrintFollowerList()
        {
            foreach (string follower in Followers.OrderBy(f => f))
            {
                Console.WriteLine($"*  {follower}");
            }
        }
    }
}
