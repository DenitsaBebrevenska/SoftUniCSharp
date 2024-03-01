namespace Animals
{
    public class Tomcat : Cat
    {
        public override string Type => "Tomcat";
        public Tomcat(string name, int age) : base(name, age, "Male")
        {
        }

        public override string ProduceSound() => "MEOW";
    }
}
