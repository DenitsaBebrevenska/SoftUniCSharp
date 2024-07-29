using System.Text;
using System.Xml.Serialization;

namespace Trucks.Common;
public static class XmlHelper
{
    public static T Deserialize<T>(string xmlDocument, string rootName)
    {
        XmlRootAttribute rootAttribute = new XmlRootAttribute(rootName);
        XmlSerializer serializer = new XmlSerializer(typeof(T), rootAttribute);
        using StringReader reader = new StringReader(xmlDocument);

        return (T)serializer.Deserialize(reader);
    }

    public static string Serialize<T>(T obj, string rootName)
    {
        XmlRootAttribute rootAttribute = new XmlRootAttribute(rootName);
        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);
        XmlSerializer serializer = new XmlSerializer(typeof(T), rootName);
        StringBuilder sb = new StringBuilder();
        using StringWriter writer = new StringWriter(sb);
        serializer.Serialize(writer, obj, namespaces);

        return sb.ToString().TrimEnd();
    }
}
