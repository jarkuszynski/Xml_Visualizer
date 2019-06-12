using System.Collections.Generic;
using System.Xml.Serialization;

namespace AppModel.Model
{
    [XmlRoot(ElementName = "clubs")]
    public class Clubs
    {
        [XmlElement(ElementName = "club")]
        public List<Club> Club { get; set; }
    }
}