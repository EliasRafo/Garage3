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
        // Private field to store the DbContext used by the service.
        private readonly Garage3WebContext _context;

        // Constructor that injects the Garage3WebContext into the service.
        public GarageService(Garage3WebContext context)
        {
            _context = context;
        }

        // Method to asynchronously get the capacity of the garage.
        public async Task<int> GetCapacity()
        {
            // Retrieves the first garage from the database and returns its capacity.
            var garage = await _context.Garage.FirstOrDefaultAsync();
            return garage.Capacity;
        }

        // Method to asynchronously get a list of VehicleTypesDto containing the vehicle types and their counts.
        public async Task<List<VehicleTypesDto>> GetVehicleTypes()
        {
            // Groups vehicles by type and projects the result into a list of VehicleTypesDto.
            return await _context.Vehicle
                .GroupBy(x => x.VehicleType.Type)
                .Select(grp => new VehicleTypesDto(grp.Key, grp.Count()))
                .ToListAsync();
        }

        // Method to asynchronously get the number of customers.
        public async Task<int> GetCustomerNumber()
        {
            // Returns the count of customers in the database.
            return await _context.Customer.CountAsync();
        }

        // Method to asynchronously get the number of currently parked vehicles.
        public async Task<int> GetCurrentlyParked()
        {
            // Returns the count of spots with Active set to true.
            return await _context.Spot.Where(s => s.Active == true).CountAsync();
        }

        // Method to asynchronously get the total number of vehicles.
        public async Task<int> GetVehiclesNumber()
        {
            // Returns the count of vehicles in the database.
            return await _context.Vehicle.CountAsync();
        }

        // Method to asynchronously check if a customer with a given Social Security Number (ssn) is a member.
        public async Task<Customer> IsMember(string ssn)
        {
            // Retrieves a customer based on the provided Social Security Number.
            var customer = await _context.Customer.Where(c => c.SocialNum == ssn).FirstOrDefaultAsync();
            return customer;
        }

        // Method to asynchronously get a list of vehicle types.
        public async Task<List<VehicleType>> GetTypes()
        {
            // Returns a list of all vehicle types.
            return await _context.VehicleType.ToListAsync();
        }

        // Method to asynchronously add a vehicle to the database.
        public async Task<bool> AddVehicle(Vehicle vehicle)
        {
            // Checks if a vehicle with the same registration number already exists.
            var v = _context.Vehicle.Where(e => e.RegNum.StartsWith(vehicle.RegNum)).FirstOrDefault();

            if (v is null)
            {
                // If the vehicle does not exist, adds it to the database and saves changes.
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                // If the vehicle already exists, returns false.
                return false;
            }
        }

        public async Task<IEnumerable<Spot>> GetSpot() 
        { // add customer information
            return await _context.Spot.Where(s => s.Active == true)
        .Include(s => s.Vehicle)
        .ThenInclude(v => v.VehicleType)
        .Include(s => s.Garage)
        .ToListAsync();
        }
    }

}
