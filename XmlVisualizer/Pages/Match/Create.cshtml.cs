using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppModel.Model;
using XmlVisualizer.Data;
using XmlVisualizer.Models;

namespace XmlVisualizer.Pages.Match
{
    public class CreateModel : PageModel
    {
        private readonly ModelContext _context;

        public CreateModel(ModelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string id)
        {
            Matches_id = id;
            return Page();
        }

        [BindProperty]
        public AppModel.Model.Match Match { get; set; }

        [BindProperty]
        public string Matches_id { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Match.Id = Guid.NewGuid();
            _context.History.Finals.Matches.Find(m => m.Matches_id == Matches_id).Match.Add(Match);

            return RedirectToPage("./Index", new {id = Matches_id});
        }
    }
}