using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace AppModel.Model
{
    [XmlRoot(ElementName = "result")]
    public class Result
    {
        [XmlAttribute(AttributeName = "score")]
        public string Score { get; set; }
        [XmlText]
        public string Text { get; set; }
        [Key]
        [XmlIgnore]
        public Guid Id { get; set; }
    }
}