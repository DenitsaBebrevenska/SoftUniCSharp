using WildFarm.Factories;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    public class Engine
    {
        public void Run()
        {
            AnimalFactory animalFactory = new AnimalFactory();
            FoodFactory foodFactory = new FoodFactory();
            List<Animal> animals = new List<Animal>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] animalDetails = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string[] foodDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Animal animal = animalFactory.CreateAnimal(animalDetails);
                    animals.Add(animal);
                    Console.WriteLine(animal.AskForFood());
                    Food food = foodFactory.CreateFood(foodDetails[0], int.Parse(foodDetails[1]));
                    animal.EatFood(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            animals.ForEach(a => Console.WriteLine(a.ToString()));
        }
    }
}
