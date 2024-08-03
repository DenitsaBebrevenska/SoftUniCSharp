using System.Text;
using System.Xml.Serialization;

namespace TravelAgency.Common;
public static class XmlHelper
{
    public static T Deserialize<T>(string inputXml, string rootName)
    {
        XmlRootAttribute root = new XmlRootAttribute(rootName);
        XmlSerializer serializer = new XmlSerializer(typeof(T), root);
        StringReader reader = new StringReader(inputXml);

        return (T)serializer.Deserialize(reader);
    }

    public static string Serialize<T>(T obj, string rootName)
    {
        XmlRootAttribute root = new XmlRootAttribute(rootName);
        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);
        XmlSerializer serializer = new XmlSerializer(typeof(T), root);
        StringBuilder sb = new StringBuilder();
        StringWriter writer = new StringWriter(sb);
        serializer.Serialize(writer, obj, namespaces);
        return sb.ToString().TrimEnd();
    }
}
