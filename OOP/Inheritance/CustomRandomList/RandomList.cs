namespace CustomRandomList
{
    public class RandomList: List<string>
    {
        private Random random = new ();
        public string RandomString()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            int index = random.Next(0, this.Count);

            string stringToRemove = this[index];
            this.RemoveAt(index);

            return stringToRemove;
        }
    }
}
