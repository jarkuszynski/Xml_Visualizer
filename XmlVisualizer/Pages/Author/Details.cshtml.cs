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
    public class DetailsModel : PageModel
    {
        private readonly ModelContext _context;

        public DetailsModel(ModelContext context)
        {
            _context = context;
        }

        public AppModel.Model.Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author = _context.History.Authors.Author.FirstOrDefault(m => m.Album == id);

            if (Author == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
