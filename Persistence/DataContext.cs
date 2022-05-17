using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class DataContext: DbContext
    {
        // public DataContext(){}

        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured) {
                options.UseSqlite("A FALLBACK CONNECTION STRING");
            }
        }

        public DbSet<Activity> Activities {get; set;}
    }
}