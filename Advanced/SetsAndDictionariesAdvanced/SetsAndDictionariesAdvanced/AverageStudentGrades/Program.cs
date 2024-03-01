namespace AverageStudentGrades
{
    internal class Program
    {
        static void Main()
        {
            byte entryCount = byte.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < entryCount; i++)
            {
                string[] entry = Console.ReadLine().Split();
                string name = entry[0];
                decimal grade = decimal.Parse(entry[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal>());
                }

                students[name].Add(grade);
            }

            foreach (var kvp in students)
            {
                Console.WriteLine($"{kvp.Key} -> {string.Join(' ',kvp.Value)} (avg: {kvp.Value.Average():F2})");
            }
        }
    }
}
