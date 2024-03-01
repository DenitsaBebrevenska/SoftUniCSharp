using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranking
{
    internal class Contestant
    {
        public string Name { get; set; }

        public Dictionary<string, int> Contests { get; set; }

        public int TotalScore => Contests.Sum(x => x.Value);

        public Contestant(string name)
        {
            Name = name;
            Contests = new Dictionary<string, int>();
        }

        public override string ToString()
        {
            StringBuilder contestantInfo = new();
            contestantInfo.Append(Name);

            foreach (var kvp in Contests.OrderByDescending(c => c.Value))
            {
                contestantInfo.Append($"\n#  {kvp.Key} -> {kvp.Value}");
            }

            return contestantInfo.ToString();
        }
    }
}
