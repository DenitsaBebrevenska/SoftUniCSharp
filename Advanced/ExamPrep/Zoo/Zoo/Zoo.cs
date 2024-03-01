using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals = new List<Animal>();

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public IReadOnlyCollection<Animal> Animals => animals.AsReadOnly();

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            if (animals.Count == Capacity)
            {
                return "The zoo is full.";
            }

            animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int count = animals.Count(a => a.Species == species);
            animals.RemoveAll(a => a.Species == species);
            return count;
        }
        public List<Animal> GetAnimalsByDiet(string diet) => animals.Where(a => a.Diet == diet).ToList();

        public Animal GetAnimalByWeight(double weight) => animals.FirstOrDefault(a => a.Weight.Equals(weight));

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = animals.Count(a => a.Length >= minimumLength && a.Length <= maximumLength);
            return
                $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
