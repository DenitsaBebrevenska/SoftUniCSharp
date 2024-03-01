namespace Prototype
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        public override SandwichPrototype Clone()
        {
            Console.WriteLine($"Cloning sandwich with ingredients: {GetIngredients()}");

            return MemberwiseClone() as SandwichPrototype; //that is a shallow copy which can lead to some problems
        }

        private string GetIngredients()
            => $"{bread}, {meat}, {cheese}, {veggies}";
    }
}
