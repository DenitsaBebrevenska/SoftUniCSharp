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
}
