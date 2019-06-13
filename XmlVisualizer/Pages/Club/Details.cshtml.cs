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

namespace XmlVisualizer.Pages.Club
{
    public class DetailsModel : PageModel
    {
        private readonly ModelContext _context;

        public DetailsModel(ModelContext context)
        {
            _context = context;
        }

        public AppModel.Model.Club Club { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Club = _context.History.Clubs.Club.FirstOrDefault(m => m.Club_id == id);

            if (Club == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
