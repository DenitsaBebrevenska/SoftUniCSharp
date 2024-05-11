using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Utilities;
public class XmlHelper
{
    public T Deserialize<T>(string inputXml, string rootName)
    {
        XmlRootAttribute root = new XmlRootAttribute(rootName);
        XmlSerializer serializer = new XmlSerializer(typeof(T), root);
        using StringReader reader = new StringReader(inputXml);
        var obj = (T)serializer.Deserialize(reader);

        return obj;
    }

    public string Serialize<T>(T obj, string rootName)
    {
        XmlRootAttribute root = new XmlRootAttribute(rootName);
        XmlSerializer serializer = new XmlSerializer(typeof(T), root);
        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);
        StringBuilder sb = new StringBuilder();
        using StringWriter writer = new StringWriter(sb);

        serializer.Serialize(writer, obj, namespaces);

        return sb.ToString().TrimEnd();
    }
}
