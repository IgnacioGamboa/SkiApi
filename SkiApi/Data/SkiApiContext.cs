using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkiApi.Models;

namespace SkiApi.Data
{
    public class SkiApiContext : DbContext
    {
        public SkiApiContext (DbContextOptions<SkiApiContext> options)
            : base(options)
        {
        }

        public DbSet<SkiApi.Models.Skier> Skiers { get; set; }
        public DbSet<SkiApi.Models.Winner> Winners { get; set; }
        public DbSet<SkiApi.Models.Race> Races { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Race>()
                .HasMany(p => p.Winners)
                .WithOne(b => b.Race);

            modelBuilder.Entity<Winner>()
                 .HasKey(pc => new { pc.Year , pc.RaceId });
        }
    }
}
