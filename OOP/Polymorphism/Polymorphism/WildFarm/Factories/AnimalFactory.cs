using WildFarm.Models.Animals;

namespace WildFarm.Factories
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(string[] animalDetails)
        {
            switch (animalDetails[0])
            {
                case "Owl":
                    return new Owl(animalDetails[1], double.Parse(animalDetails[2]),
                        double.Parse(animalDetails[3]));
                    break;
                case "Hen":
                    return new Hen(animalDetails[1], double.Parse(animalDetails[2]),
                        double.Parse(animalDetails[3]));
                    break;
                case "Mouse":
                    return new Mouse(animalDetails[1], double.Parse(animalDetails[2]),
                        animalDetails[3]);
                    break;
                case "Dog":
                    return new Dog(animalDetails[1], double.Parse(animalDetails[2]),
                        animalDetails[3]);
                    break;
                case "Cat":
                    return new Cat(animalDetails[1], double.Parse(animalDetails[2]),
                        animalDetails[3], animalDetails[4]);
                    break;
                case "Tiger":
                    return new Tiger(animalDetails[1], double.Parse(animalDetails[2]),
                        animalDetails[3], animalDetails[4]);
                    break;
                default:
                    throw new ArgumentException("Invalid type animal");
                    break;
            }
        }
    }
}
