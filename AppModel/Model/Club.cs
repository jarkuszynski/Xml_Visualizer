using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace AppModel.Model
{
    [XmlRoot(ElementName = "club")]
    public class Club
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "club_id")]
        [Key]
        public string Club_id { get; set; }
        [XmlAttribute(AttributeName = "league")]
        public string League { get; set; }
    }
}