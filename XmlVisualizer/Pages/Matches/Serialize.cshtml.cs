﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppModel.Model;
using XmlSer;
using XmlVisualizer.Data;
using XmlVisualizer.Models;

namespace XmlVisualizer.Pages.Matches
{
    public class SerializeModel : PageModel
    {
        private readonly ModelContext _context;

        public SerializeModel(ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AppModel.Model.Matches Matches { get; set; }


        public async Task<IActionResult> OnPostAsync(string id)
        {
            Serializer serializer = new Serializer();
            string workingDirectory = Environment.CurrentDirectory;
            serializer.Serialize(_context.History, workingDirectory + "\\wwwroot\\mock\\history_serialized.xml");
            return RedirectToPage("./Index");
        }
    }
}
