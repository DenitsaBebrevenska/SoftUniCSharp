namespace Animals
{
    public abstract class Animal
    {
        private string _name;
        private int _age;
        private string _gender;
        public virtual string Type => default;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                _name = value;
            }
        }
        public int Age
        {
            get => _age;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                _age = value;
            }
        }

        public string Gender
        {
            get => _gender;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                _gender = value;
            }
        }

        protected Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{Type}{Environment.NewLine}" +
                $"{Name} {Age} {Gender} {Environment.NewLine}" +
                $"{ProduceSound()}";
        }
    }
}
