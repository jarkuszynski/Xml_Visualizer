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
    public class DeleteModel : PageModel
    {
        private readonly ModelContext _context;

        public DeleteModel(ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AppModel.Model.League League { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            League = _context.History.Leagues.League.FirstOrDefault(m => m.League_id == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            League = _context.History.Leagues.League.Find( l => l.League_id == id);

            if (League != null)
            {
                _context.History.Leagues.League.Remove(League);
            }

            return RedirectToPage("./Index");
        }
    }
}
