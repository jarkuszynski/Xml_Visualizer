using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace AppModel.Model
{
    [XmlRoot(ElementName = "payment")]
    public class Payment
    {
        [XmlAttribute(AttributeName = "currency")]
        public string Currency { get; set; }
        [XmlText]
        public string Text { get; set; }
        [Key]
        [XmlIgnore]
        public Guid Id { get; set; }
    }
}