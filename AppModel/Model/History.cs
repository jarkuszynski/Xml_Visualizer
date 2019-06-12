/* 
   Licensed under the Apache License, Version 2.0

   http://www.apache.org/licenses/LICENSE-2.0
   */

using System.Xml.Serialization;

namespace AppModel.Model
{
    [XmlRoot(ElementName = "history")]
    public class History
    {
        [XmlElement(ElementName = "leagues")]
        public Leagues Leagues { get; set; }
        [XmlElement(ElementName = "clubs")]
        public Clubs Clubs { get; set; }
        [XmlElement(ElementName = "finals")]
        public Finals Finals { get; set; }
        [XmlElement(ElementName = "authors")]
        public Authors Authors { get; set; }
    }

}
