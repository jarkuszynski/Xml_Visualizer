using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AppModel.Model;
using XmlSer;

namespace XmlVisualizer.Data
{
    public class ModelContext
    {
        public History History { get; set; }
        private Serializer serializer = new Serializer();

        public ModelContext()
        {
            string filePath = @"C:\Users\Johnny\source\repos\XmlVisualizer\XmlVisualizer\wwwroot\mock\history.xml";
            string workingDirectory = Environment.CurrentDirectory;
            filePath = workingDirectory + "\\wwwroot\\mock\\history.xml";
            History = serializer.Deserialize(filePath);
            foreach (Matches finalMatches in History.Finals.Matches)
            {
                foreach (Match match in finalMatches.Match)
                {
                    match.Id = Guid.NewGuid();
                    match.Goals.Id = Guid.NewGuid();
                    match.Goals.NormalTime.Id = Guid.NewGuid();
                    foreach (Result result in match.Goals.NormalTime.Result)
                    {
                        result.Id = Guid.NewGuid();
                    }

                    if (match.Goals._Penalties == "true")
                    {
                        match.Goals.Penalties.Id = Guid.NewGuid();
                        foreach (Result result in match.Goals.Penalties.Result)
                        {
                            result.Id = Guid.NewGuid();
                        }
                    }
                    
                    match.Info.Id = Guid.NewGuid();
                    match.Info.PricePerTicket.Id = Guid.NewGuid();
                    foreach (Payment payment in match.Info.PricePerTicket.Payment)
                    {
                        payment.Id = Guid.NewGuid();
                    }
                }
            }
        }
    }
}
