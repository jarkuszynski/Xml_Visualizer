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

namespace XmlVisualizer.Pages.Matches
{
    public class DeleteModel : PageModel
    {
        private readonly ModelContext _context;

        public DeleteModel(ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AppModel.Model.Matches Matches { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Matches = _context.History.Finals.Matches.FirstOrDefault(m => m.Matches_id == id);

            if (Matches == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Matches = _context.History.Finals.Matches.Find(a => a.Matches_id == id);
            if (Matches != null)
            {
                _context.History.Finals.Matches.Remove(Matches);
            }

            return RedirectToPage("./Index");
        }
    }
}
