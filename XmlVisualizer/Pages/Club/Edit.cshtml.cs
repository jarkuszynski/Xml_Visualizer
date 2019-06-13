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

namespace XmlVisualizer.Pages.Club
{
    public class EditModel : PageModel
    {
        private readonly ModelContext _context;

        public EditModel(ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AppModel.Model.Club Club { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Club = _context.History.Clubs.Club.FirstOrDefault(m => m.Club_id == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            int index = _context.History.Clubs.Club.FindIndex(i => i.Club_id == Club.Club_id);
            _context.History.Clubs.Club[index] = Club;
            return RedirectToPage("./Index");
        }
    }
}
