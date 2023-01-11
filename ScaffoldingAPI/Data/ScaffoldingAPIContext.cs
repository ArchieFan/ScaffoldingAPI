using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScaffoldingAPI.Models;

namespace ScaffoldingAPI.Data
{
    public class ScaffoldingAPIContext : DbContext
    {
        public ScaffoldingAPIContext (DbContextOptions<ScaffoldingAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ScaffoldingAPI.Models.Scaffold> Scaffold { get; set; } = default!;
    }
}
