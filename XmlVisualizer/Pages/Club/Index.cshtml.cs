using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppModel.Model;
using XmlVisualizer.Data;
using XmlVisualizer.Models;

namespace XmlVisualizer.Pages.Club
{
    public class IndexModel : PageModel
    {
        private readonly ModelContext _context;

        public IndexModel(ModelContext context)
        {
            _context = context;
        }

        public IList<AppModel.Model.Club> Club { get;set; }

        public async Task OnGetAsync()
        {
            Club = _context.History.Clubs.Club;
        }
    }
}
