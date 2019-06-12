using System.Collections.Generic;
using System.Xml.Serialization;

namespace AppModel.Model
{
    [XmlRoot(ElementName = "authors")]
    public class Authors
    {
        [XmlElement(ElementName = "author")]
        public List<Author> Author { get; set; }
    }
}