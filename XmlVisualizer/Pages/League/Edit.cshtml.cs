using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppModel.Model;
using XmlVisualizer.Data;
using XmlVisualizer.Models;

namespace XmlVisualizer.Pages.League
{
    public class EditModel : PageModel
    {
        private readonly ModelContext _context;

        public EditModel(ModelContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            int index = _context.History.Leagues.League.FindIndex(i => i.League_id == League.League_id);
            _context.History.Leagues.League[index] = League;
            return RedirectToPage("./Index");
        }
    }
}
