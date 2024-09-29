using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TinyCash.Models;

namespace TinyCash.Data
{
    public class HomeContext : DbContext
    {
        public HomeContext (DbContextOptions<HomeContext> options)
            : base(options)
        {
        }

        public DbSet<Mission> Mission { get; set; } = default!;
        public DbSet<Objective> Objectives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mission>().ToTable("Mission");
            modelBuilder.Entity<Objective>().ToTable("Objective");
        }
    }
}
