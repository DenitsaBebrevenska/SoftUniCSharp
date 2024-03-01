namespace Animals
{
    public abstract class Animal
    {
        protected Animal(string name, string favouriteFood)
        {
            this.name = name;
            this.favouriteFood = favouriteFood;
        }

        private string name;
        private string favouriteFood;

        public virtual string ExplainSelf() => $"I am Peter and my {name} food is {favouriteFood}";
    }
}
