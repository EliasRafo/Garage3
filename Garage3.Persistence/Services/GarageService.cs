using Garage3.Core.Entities;
using Garage3.Core.Models;
using Garage3.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Garage3.Persistence.Services
{
    public class GarageService : IGarageService
    {
        private readonly Garage3WebContext _context;
        public GarageService(Garage3WebContext context)
        {
            _context = context;
        }

        public async Task<int> GetCapacity()
        {
            var garage = await _context.Garage.FirstOrDefaultAsync();
            return garage.Capacity;
        }

        public async Task<List<VehicleTypesDto>> GetVehicleTypes()
        {
            return await _context.Vehicle.GroupBy(x => x.VehicleType.Type).Select(grp => new VehicleTypesDto(grp.Key, grp.Count())).ToListAsync();
        }

        public async Task<int> GetCustomerNumber()
        {
            return await _context.Customer.CountAsync();
        }

        public async Task<int> GetCurrentlyParked()
        {
            return await _context.Spot.Where(s => s.Active == true).CountAsync();
        }

        public async Task<int> GetVehiclesNumber()
        {
            return await _context.Vehicle.CountAsync();
        }

        // Method to asynchronously check if a customer with a given Social Security Number (ssn) is a member.
        public async Task<Customer> IsMember(string ssn)
        {
            // Retrieves a customer based on the provided Social Security Number.
            var customer = await _context.Customer.Where(c => c.SocialNum == ssn).FirstOrDefaultAsync();
            return customer;
        }

        public async Task<List<VehicleType>> GetTypes()
        {
            return await _context.VehicleType.ToListAsync();
        }

        public async Task<bool> AddVehicle(Vehicle vehicle)
        {
            var v = _context.Vehicle.Where(e => e.RegNum.StartsWith(vehicle.RegNum)).FirstOrDefault();
            if (v is null)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<IEnumerable<Spot>> GetSpot()
        {
            // Change to use of viewmodel+Select, discuss what data we need.
            return await _context.Spot.Where(s => s.Active == true)
                .Include(s => s.Vehicle)
                .ThenInclude(v => v.VehicleType)
                .Include(s => s.Vehicle.Customer)
                .Include(s => s.Garage)
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerByID(int id)
        {
            Customer x = await _context.Customer.Where(s => s.Id == id).FirstOrDefaultAsync();
            return x;
        }

        public async Task<Spot> GetSpotByID(int id)
        {
            return await _context.Spot.Where(s => s.Id == id)
                .Include(s => s.Vehicle)
                .ThenInclude(v => v.VehicleType)
                .Include(s => s.Vehicle.Customer)
                .Include(s => s.Garage).FirstOrDefaultAsync();
        }

        //    public async Task<IEnumerable<Spot>> GetSpot() 
        //    { // add customer information
        //        return await _context.Spot.Where(s => s.Active == true)
        //    .Include(s => s.Vehicle)
        //    .ThenInclude(v => v.VehicleType)
        //    .Include(s => s.Garage)
        //    .ToListAsync();
        //    }
        public async void UpdateSpot(Spot spot)
        {
            var s = _context.Spot.First(a => a.Id == spot.Id);
            s.Active = false;
            s.CheckOut = spot.CheckOut;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByCustomerId(int id)
        {
            return await _context.Vehicle.Where(v => v.CustomerId == id)
                .Include(v => v.VehicleType).ToListAsync();
        }

        // Method to asynchronously create a new customer in the database.
        public async Task<bool> CreateCustomer(Customer customer)
        {
            // Check if a customer with the same Social Security Number already exists.
            var existingCustomer = await _context.Customer
                .Where(c => c.SocialNum == customer.SocialNum)
                .FirstOrDefaultAsync();

            // If no existing customer is found, proceed with creating the new customer.
            if (existingCustomer is null)
            {
                // Add the new customer to the database.
                _context.Add(customer);

                // Save changes to the database.
                await _context.SaveChangesAsync();

                // Return true to indicate successful creation.
                return true;
            }
            else
            {
                // If a customer with the same Social Security Number exists, return false
                // to indicate that the creation was not successful.
                return false;
            }
        }
    }
}
