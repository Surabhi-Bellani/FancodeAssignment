using System.Configuration;
using System.Xml.Linq;
using System.Xml.Serialization;

public class Config
{
    public string Uri { get; set; }

      public static Config LoadConfig()
    {
          var doc = XDocument.Load("config.xml");
         var uri = doc.Root.Element("uri").Value;
        return new Config { Uri = uri };
    }
}

