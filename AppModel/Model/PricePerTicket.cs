using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace AppModel.Model
{
    [XmlRoot(ElementName = "pricePerTicket")]
    public class PricePerTicket
    {
        [XmlElement(ElementName = "payment")]
        public List<Payment> Payment { get; set; }
        [Key]
        [XmlIgnore]
        public Guid Id { get; set; }
    }
}