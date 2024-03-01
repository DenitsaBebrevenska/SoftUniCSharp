using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public List<Person> People { get; set; }

        public Family()
        {
            People = new List<Person>();
        }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            if (People.Count > 0)
            {
                return People.OrderByDescending(p => p.Age).ToList()[0];
            }

            return null;
        }
    }
}
