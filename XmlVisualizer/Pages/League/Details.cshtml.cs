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

namespace XmlVisualizer.Pages.League
{
    public class DetailsModel : PageModel
    {
        private readonly ModelContext _context;

        public DetailsModel(ModelContext context)
        {
            _context = context;
        }

        public AppModel.Model.League League { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            League = _context.History.Leagues.League.FirstOrDefault(m => m.League_id == id);

            if (League == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
