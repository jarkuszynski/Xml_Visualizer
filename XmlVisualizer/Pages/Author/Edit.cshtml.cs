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

namespace XmlVisualizer.Pages.Author
{
    public class EditModel : PageModel
    {
        private readonly ModelContext _context;

        public EditModel(ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AppModel.Model.Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Author = _context.History.Authors.Author.FirstOrDefault(m => m.Album == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            int index = _context.History.Authors.Author.FindIndex(i => i.Album == Author.Album);
            _context.History.Authors.Author[index] = Author;
            return RedirectToPage("./Index");
        }

    }
}
