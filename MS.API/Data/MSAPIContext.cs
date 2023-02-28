using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Shared.Entities;

namespace MS.API.Data
{
    public class MSAPIContext : DbContext
    {
        public MSAPIContext (DbContextOptions<MSAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MS.Shared.Entities.Machine> Machine { get; set; } = default!;
    }
}
