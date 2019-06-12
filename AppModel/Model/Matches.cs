using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace AppModel.Model
{
    [XmlRoot(ElementName = "matches")]
    public class Matches
    {
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "match")]
        public List<Match> Match { get; set; }
        [XmlAttribute(AttributeName = "matches_id")]
        [Key]
        public string Matches_id { get; set; }
    }
}