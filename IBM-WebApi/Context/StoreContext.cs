using IBM_WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Context
{
    public class StoreContext: DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options): base(options)
        {
        }

        public DbSet<PCs> Pcs { get; set; }
        public DbSet<Procesoare> Procesoare { get; set; }
        public DbSet<PlaciVideo> PlaciVideo { get; set; }
        public DbSet<Ram> Ram { get; set; }

        // todo proceduri de stocare ?
    }
}
