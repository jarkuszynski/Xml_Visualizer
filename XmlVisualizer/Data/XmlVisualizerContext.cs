using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppModel.Model;

namespace XmlVisualizer.Models
{
    public class XmlVisualizerContext : DbContext
    {
        public XmlVisualizerContext (DbContextOptions<XmlVisualizerContext> options)
            : base(options)
        {
        }

        public DbSet<AppModel.Model.Author> Author { get; set; }

        public DbSet<AppModel.Model.Match> Match { get; set; }

        public DbSet<AppModel.Model.Matches> Matches { get; set; }

        public DbSet<AppModel.Model.Club> Club { get; set; }

        public DbSet<AppModel.Model.League> League { get; set; }
    }
}
