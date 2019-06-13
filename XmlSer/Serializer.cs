using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AppModel.Model;

namespace XmlSer
{
    public class Serializer
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(History));

        public void Serialize(History history, string filePath)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("","");
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                _serializer.Serialize(stream, history, ns);
            }
        }

        public History Deserialize(string filePath)
        {
            if (!File.Exists(filePath))
                throw new Exception($"File not found: {filePath}");
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                return (History)_serializer.Deserialize(stream);
            }
        }

    }
}
