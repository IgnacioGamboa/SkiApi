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
    }
}
