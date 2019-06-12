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

namespace XmlVisualizer.Pages.Author
{
    public class DeleteModel : PageModel
    {
        private readonly ModelContext _context;

        public DeleteModel(ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AppModel.Model.Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {

            Author =  _context.History.Authors.Author.FirstOrDefault(m => m.Album == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author = _context.History.Authors.Author.Find( a => a.Album == id);

            if (Author != null)
            {
                _context.History.Authors.Author.Remove(Author);
            }

            return RedirectToPage("./Index");
        }
    }
}
