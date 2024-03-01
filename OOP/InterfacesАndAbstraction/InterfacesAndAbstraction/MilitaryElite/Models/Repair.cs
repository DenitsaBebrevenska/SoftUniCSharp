namespace MilitaryElite.Models
{
    public class Repair
    {
        public string Name { get; }
        public int HoursWorked { get; }

        public Repair(string name, int hoursWorked)
        {
            Name = name;
            HoursWorked = hoursWorked;
        }

        public override string ToString()
        {
            return $"Part Name: {Name} Hours Worked: {HoursWorked}";
        }
    }
}
