﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppModel.Model;
using XmlVisualizer.Data;
using XmlVisualizer.Models;

namespace XmlVisualizer.Pages.Match
{
    public class DeleteModel : PageModel
    {
        private readonly ModelContext _context;

        public DeleteModel(ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AppModel.Model.Match Match { get; set; }

        [BindProperty] public string Matches_Id { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppModel.Model.Match temp = new AppModel.Model.Match();
            foreach (AppModel.Model.Matches finalsMatch in _context.History.Finals.Matches)
            {
                temp = finalsMatch.Match.FirstOrDefault(m => m.Id == id);
                if (temp != null)
                {
                    Matches_Id = finalsMatch.Matches_id;
                    break;
                }
            }

            Match = temp;

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


            foreach (AppModel.Model.Matches finalsMatch in _context.History.Finals.Matches)
            {
                Match = finalsMatch.Match.FirstOrDefault(m => m.Id == id);
                if (Match != null)
                {
                    finalsMatch.Match.Remove(Match);
                    break;
                }
            }

            return RedirectToPage("./Index", new { id = Matches_Id });
        }
    }
}
