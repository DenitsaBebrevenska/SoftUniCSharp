using System.Text;
using System.Xml.Serialization;

namespace Footballers.Common;
public static class XmlHelper
{
    public static string Serialize<T>(T obj, string rootName)
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

    public static T? Deserialize<T>(string xmlString, string rootName)
    {
        XmlRootAttribute root = new XmlRootAttribute(rootName);
        XmlSerializer serializer = new XmlSerializer(typeof(T), root);
        using StringReader reader = new StringReader(xmlString);

        return (T?)serializer.Deserialize(reader);
    }
}
