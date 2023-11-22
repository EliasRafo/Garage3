using Garage3.Core.Entities;
using Garage3.Core.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage3.Persistence.Services
{
    public interface IGarageService
    {
        public Task CreateCustomer(Customer customer);

        // Asynchronously gets the capacity of the garage.
        public Task<int> GetCapacity();

        // Asynchronously gets a list of VehicleTypesDto containing the vehicle types and their counts.
        public Task<List<VehicleTypesDto>> GetVehicleTypes();

        // Asynchronously gets the number of customers.
        public Task<int> GetCustomerNumber();

        // Asynchronously gets the total number of vehicles.
        public Task<int> GetVehiclesNumber();

        // Asynchronously checks if a customer with a given Social Security Number (ssn) is a member.
        public Task<Customer> IsMember(string ssn);

        // Asynchronously gets a list of vehicle types.
        public Task<List<VehicleType>> GetTypes();

        // Asynchronously adds a vehicle to the database.
        public Task<bool> AddVehicle(Vehicle vehicle);

        // Asynchronously gets a list of currently active spots with associated vehicle and garage information.
        public Task<IEnumerable<Spot>> GetSpot();

        // Asynchronously gets the number of currently parked vehicles.
        public Task<int> GetCurrentlyParked();

        public Task<Customer> GetCustomerByID(int id);

        public Task<Spot> GetSpotByID(int id);

        public void UpdateSpot(Spot spot);

        public Task<IEnumerable<Customer>> GetCustomers();

        public Task<IEnumerable<Vehicle>> GetVehiclesByCustomerId(int id);
    }
}
