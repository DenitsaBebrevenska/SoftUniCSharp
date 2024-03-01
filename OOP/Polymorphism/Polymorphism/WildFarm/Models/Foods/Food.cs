namespace WildFarm.Models.Foods
{
    public abstract class Food
    {
        public int Quantity { get; private set; }
        protected Food(int quantity)
        {
            Quantity = quantity;
        }
    }
}
