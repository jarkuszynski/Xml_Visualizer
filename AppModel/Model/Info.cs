using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace AppModel.Model
{
    [XmlRoot(ElementName = "info")]
    public class Info
    {
        [XmlElement(ElementName = "stadium")]
        public string Stadium { get; set; }
        [XmlElement(ElementName = "date")]
        public string Date { get; set; }
        [XmlElement(ElementName = "frequency")]
        public string Frequency { get; set; }
        [XmlElement(ElementName = "pricePerTicket")]
        public PricePerTicket PricePerTicket { get; set; }
        [Key]
        [XmlIgnore]
        public Guid Id { get; set; }
    }
}