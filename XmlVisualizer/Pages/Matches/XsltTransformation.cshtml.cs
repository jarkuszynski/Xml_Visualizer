using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppModel.Model;
using XmlSer;
using XmlVisualizer.Data;
using XmlVisualizer.Models;

namespace XmlVisualizer.Pages.Matches
{
    public class XsltTransformationModel : PageModel
    {
        private readonly ModelContext _context;

        public XsltTransformationModel(ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AppModel.Model.Matches Matches { get; set; }


        public async Task<IActionResult> OnPostAsync(string id)
        {
            XslTransform xsltXmlToXml = new XslTransform();

            string workingDirectory = Environment.CurrentDirectory;
            //Load the stylesheet.
            xsltXmlToXml.Load(workingDirectory + "\\wwwroot\\mock\\history.xsl");

            //Create a new XPathDocument and load the XML data to be transformed.
            XPathDocument mydata1 = new XPathDocument(workingDirectory + "\\wwwroot\\mock\\history_serialized.xml");

            //Create an XmlTextWriter which outputs to the console.
            XmlWriter writer1 = new XmlTextWriter(workingDirectory + "\\wwwroot\\mock\\history_sum.xml", Encoding.UTF8);
            //Transform the data and send the output to the console.
            xsltXmlToXml.Transform(mydata1, null, writer1, null);
            writer1.Close();


            xsltXmlToXml.Load(workingDirectory + "\\wwwroot\\mock\\history_summary_xhtml.xsl");
            XPathDocument mydata2 = new XPathDocument(workingDirectory + "\\wwwroot\\mock\\history_sum.xml");
            XmlWriter writer2 = new XmlTextWriter(workingDirectory + "\\wwwroot\\mock\\history_sum.xhtml", Encoding.UTF8);
            xsltXmlToXml.Transform(mydata2, null, writer2, null);
            writer2.Close();
            return RedirectToPage("./Index");
        }
    }
}
