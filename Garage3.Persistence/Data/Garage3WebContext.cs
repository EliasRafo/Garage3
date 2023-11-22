using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage3.Web.Models;


namespace Garage3.Persistence.Data
{
    public class Garage3WebContext : DbContext
    {
        public readonly object Customers;
        public object Customer;
        public IEnumerable<object> Vehicles;

        public Garage3WebContext(DbContextOptions<Garage3WebContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicle { get; set; } = default!;
        public object Garage { get; set; }
        public object Garages { get; set; }
    }

    public class Vehicle
    {
    }
}
