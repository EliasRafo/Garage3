﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage3.Core.Entities;
using System.Net;

namespace Garage3.Persistence.Data
{
    // Entity Framework Core DbContext for the Garage3Web application.
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
        public object Customers { get; internal set; }

        // Method for configuring the model that defines the shape of the entities and their relationships in the database.
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
