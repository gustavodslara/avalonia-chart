using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xamarinchart.Models;

namespace avaloniachart.DataAccess
{
    public class DatabaseContext : DbContext
    {
            public DbSet<Programmer> Programmers { get; set; }

        string _dbPath;
        public DatabaseContext(string dbPath) : base()
        {
            this._dbPath = dbPath;
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Programmer>()
                .HasData(
                new Programmer { Demand = 1000, Offer = 370, Name = "Java" },
                new Programmer { Demand = 680, Offer = 430, Name = "C#" },
                new Programmer { Demand = 500, Offer = 865, Name = "NodeJS" },
                new Programmer { Demand = 724, Offer = 400, Name = "PHP" }
                );
        }

    }
}
