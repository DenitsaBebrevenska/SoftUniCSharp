namespace Animals
{
    public class StartUp
    {
        static void Main()
        {
            string input;
            List<Animal> animals = new List<Animal>();

            while ((input = Console.ReadLine()) != "Beast!")
            {
                if (input == "Beast!")
                {
                    Environment.Exit(0);
                }

                try
                {
                    string[] animalDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string name = animalDetails[0];
                    int age = int.Parse(animalDetails[1]);
                    string gender = animalDetails[2];

                    switch (input)
                    {
                        case "Frog":
                            animals.Add(new Frog(name, age, gender));
                            break;
                        case "Dog":
                            animals.Add(new Dog(name, age, gender));
                            break;
                        case "Cat":
                            animals.Add(new Cat(name, age, gender));
                            break;
                        case "Kitten":
                            animals.Add(new Kitten(name, age));
                            break;
                        case "Tomcat":
                            animals.Add(new Tomcat(name, age));
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
