using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace AppModel.Model
{
    [XmlRoot(ElementName = "league")]
    public class League
    {
        [XmlAttribute(AttributeName = "league_id")]
        [Key]
        public string League_id { get; set; }
        [XmlAttribute(AttributeName = "nationality")]
        public string Nationality { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}