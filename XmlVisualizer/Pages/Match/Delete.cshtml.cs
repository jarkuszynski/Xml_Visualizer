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
    public class DeleteModel : PageModel
    {
        private readonly XmlVisualizer.Models.XmlVisualizerContext _context;

        public DeleteModel(XmlVisualizer.Models.XmlVisualizerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Match Match { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Match = await _context.Match.FirstOrDefaultAsync(m => m.Id == id);

            if (Match == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Match = await _context.Match.FindAsync(id);

            if (Match != null)
            {
                _context.Match.Remove(Match);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
