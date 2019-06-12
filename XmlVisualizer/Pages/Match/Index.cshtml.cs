using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppModel.Model;
using XmlVisualizer.Models;

namespace XmlVisualizer.Pages.Match
{
    public class IndexModel : PageModel
    {
        private readonly XmlVisualizer.Models.XmlVisualizerContext _context;

        public IndexModel(XmlVisualizer.Models.XmlVisualizerContext context)
        {
            _context = context;
        }

        public IList<Match> Match { get;set; }

        public async Task OnGetAsync()
        {
            Match = _context
        }
    }
}
