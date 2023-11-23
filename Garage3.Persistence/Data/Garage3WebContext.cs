using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage3.Core.Entities;

namespace Garage3.Persistence.Data
{
    public class Garage3WebContext : DbContext
    {
        public Garage3WebContext(DbContextOptions<Garage3WebContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicle { get; set; } = default!;

        public DbSet<VehicleType> VehicleType { get; set; } = default!;

        public DbSet<Garage> Garage { get; set; } = default!;

        public DbSet<Spot> Spot { get; set; } = default!;

        // DbSet property for the Customer entity, representing a table in the database.
        public DbSet<Customer> Customer { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        
    }
        }
}
