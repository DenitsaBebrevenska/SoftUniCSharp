namespace DetailPrinter
{
    public abstract class BaseEmployee
    {
        public string Name { get; private set; }

        protected BaseEmployee(string name)
        {
            Name = name;
        }

        public virtual string GetDetails() => Name;
    }
}
