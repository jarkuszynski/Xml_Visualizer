using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace AppModel.Model
{
    [XmlRoot(ElementName = "match")]
    public class Match
    {
        [XmlElement(ElementName = "goals")]
        public Goals Goals { get; set; }
        [XmlElement(ElementName = "info")]
        public Info Info { get; set; }
        [XmlAttribute(AttributeName = "homeTeam")]
        public string HomeTeam { get; set; }
        [XmlAttribute(AttributeName = "awayTeam")]
        public string AwayTeam { get; set; }
        [Key]
        [XmlIgnore]
        public Guid Id { get; set; }
    }
}