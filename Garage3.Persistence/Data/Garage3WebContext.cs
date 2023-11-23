using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage3.Core.Entities;
using System.Net;

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
            modelBuilder.Entity<Garage>().HasData(new Garage
            {
                Id = 1,
                Capacity = 20,
                GarageName = "Garage3"
            });
            List<Spot> spots = new List<Spot>();
            for (int i = 1; i <= 20; i++) {
                Spot spot = new Spot()
                {
                    Id = i,
                    Active = false,
                    CheckIn = DateTime.Now,
                    CheckOut = DateTime.Now,
                    Address = i,
                    GarageId = 1
                };
                spots.Add(spot);
            }
            modelBuilder.Entity<Spot>().HasData(spots);

                
                

           
        }
    }
}
