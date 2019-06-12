using System.Collections.Generic;
using System.Xml.Serialization;

namespace AppModel.Model
{
    [XmlRoot(ElementName = "finals")]
    public class Finals
    {
        [XmlElement(ElementName = "matches")]
        public List<Matches> Matches { get; set; }
    }
}