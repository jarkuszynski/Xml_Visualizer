using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace AppModel.Model
{
    [XmlRoot(ElementName = "goals")]
    public class Goals
    {
        [XmlElement(ElementName = "normalTime")]
        public NormalTime NormalTime { get; set; }
        [XmlElement(ElementName = "penalties")]
        public Penalties Penalties { get; set; }
        [XmlAttribute(AttributeName = "penalties")]
        public string _Penalties { get; set; }
        [Key]
        [XmlIgnore]
        public Guid Id { get; set; }
    }
}