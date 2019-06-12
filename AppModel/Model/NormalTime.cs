using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace AppModel.Model
{
    [XmlRoot(ElementName = "normalTime")]
    public class NormalTime
    {
        [XmlElement(ElementName = "result")]
        public List<Result> Result { get; set; }
        [Key]
        [XmlIgnore]
        public Guid Id { get; set; }
    }
}