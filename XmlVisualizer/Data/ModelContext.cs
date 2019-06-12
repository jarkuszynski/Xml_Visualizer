using System;
using System.Collections.Generic;
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
            History = serializer.Deserialize(filePath);
            foreach (Matches finalMatches in History.Finals.Matches)
            {
                foreach (Match match in finalMatches.Match)
                {
                    match.Id = new Guid();
                    match.Goals.Id = new Guid();
                    match.Goals.NormalTime.Id = new Guid();
                    foreach (Result result in match.Goals.NormalTime.Result)
                    {
                        result.Id = new Guid();
                    }
                    match.Goals.Penalties.Id = new Guid();
                    foreach (Result result in match.Goals.Penalties.Result)
                    {
                        result.Id = new Guid();
                    }
                    match.Info.Id = new Guid();
                    match.Info.PricePerTicket.Id = new Guid();
                    foreach (Payment payment in match.Info.PricePerTicket.Payment)
                    {
                        payment.Id = new Guid();
                    }
                }


            }
        }
    }
}
