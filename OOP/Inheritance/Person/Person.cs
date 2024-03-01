namespace Person
{
    public class Person
    {
        private string _name;
        private int _age;

        public string Name { get; set; }

        public virtual int Age
        {
            get => _age;
            set
            {
                if (value > 0)
                {
                    _age = value;
                }
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
