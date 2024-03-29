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
    public class IndexModel : PageModel
    {
        private readonly ModelContext _context;

        public IndexModel(ModelContext context)
        {
            _context = context;
        }

        public IList<AppModel.Model.Match> Match { get;set; }
        public string Matches_id { get; set; }

        public async Task OnGetAsync(string id)
        {
            Matches_id = id;

            Match = _context.History.Finals.Matches.Find(m => m.Matches_id == id).Match;
        }
    }
}
