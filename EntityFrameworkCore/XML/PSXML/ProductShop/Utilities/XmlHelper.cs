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
}
