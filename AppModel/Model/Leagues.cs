using System.Collections.Generic;
using System.Xml.Serialization;

namespace AppModel.Model
{
    [XmlRoot(ElementName = "leagues")]
    public class Leagues
    {
        [XmlElement(ElementName = "league")]
        public List<League> League { get; set; }
    }
}