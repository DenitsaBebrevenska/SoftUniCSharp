using System.Xml.Serialization;

namespace Cadastre.Common;
public static class XmlHelper
{
    public static T Deserialize<T>(string inputXml, string rootName)
    {
        XmlRootAttribute root = new XmlRootAttribute(rootName);
        XmlSerializer serializer = new XmlSerializer(typeof(T), root);
        StringReader reader = new StringReader(inputXml);

        return (T)serializer.Deserialize(reader);
    }
}
