using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage3.Core.Entities;

namespace Garage3.Persistence.Data
{
    // This class represents the Entity Framework Core DbContext for the Garage3Web application.
    public class Garage3WebContext : DbContext
    {
        // Constructor that takes DbContextOptions as a parameter and calls the base constructor with those options.
        public Garage3WebContext(DbContextOptions<Garage3WebContext> options)
            : base(options)
        {
        }

        // DbSet property for the Vehicle entity, representing a table in the database.
        public DbSet<Vehicle> Vehicle { get; set; } = default!;

        // DbSet property for the VehicleType entity, representing a table in the database.
        public DbSet<VehicleType> VehicleType { get; set; } = default!;

        // DbSet property for the Garage entity, representing a table in the database.
        public DbSet<Garage> Garage { get; set; } = default!;

        // DbSet property for the Spot entity, representing a table in the database.
        public DbSet<Spot> Spot { get; set; } = default!;

        // DbSet property for the Customer entity, representing a table in the database.
        public DbSet<Customer> Customer { get; set; } = default!;

        // Method for configuring the model that defines the shape of the entities and their relationships in the database.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Uncommented code is a sample configuration for a many-to-many relationship between Vehicle and Spot entities,
            // using an intermediary entity called Spot.

            // modelBuilder.HasMany(s => s.Vehicle)
            //     .WithMany(c => c.Spot)
            //     .UsingEntity<Spot>(
            //         e => e.HasOne(e => e.Vehicle).WithMany(c => c.Spot),
            //         e => e.HasKey(e => new { e.VehicleId, e.SpotId }));

            // Calls the base implementation of OnModelCreating to apply additional configurations.
            base.OnModelCreating(modelBuilder);
        }
    }
}
