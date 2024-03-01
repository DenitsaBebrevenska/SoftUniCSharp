namespace SoftUniDI.Attributes;
[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field)]
public class Named : Attribute
{
    public Named(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
