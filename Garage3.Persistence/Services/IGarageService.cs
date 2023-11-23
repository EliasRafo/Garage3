﻿using Garage3.Core.Entities;
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
        public Task<int> GetCapacity();
        public Task<List<VehicleTypesDto>> GetVehicleTypes();
        public Task<int> GetCustomerNumber();
        public Task<int> GetVehiclesNumber();

        public Task<Customer> IsMember(string ssn);

        public Task<ICollection<Vehicle>> GetVehiclesByCustomerID(int id);

        public Task<Vehicle?> GetVehicleByID(int VehicleId);

        public Task<bool> VehicleIsParked(int VehicleId);

        public Task<List<VehicleType>> GetTypes();
        public Task<bool> AddVehicle(Vehicle vehicle);

        public Task<bool> ParkVehicle(ParkVihecle parkVihecle);

        public Task<IEnumerable<Spot>> GetSpot();

        public Task<int> GetCurrentlyParked();

        public Task<Customer> GetCustomerByID(int id);

        public Task<Spot> GetSpotByID(int id);

        public void UpdateSpot(Spot spot);

        public Task<bool> VehicleExists(Vehicle vehicle);

        public Task<bool> SpotFree(int SpotId);

        public Task<bool> VehicleExists(int VehicleId);

        public Task<List<Vehicle>> SearchMatchAsync(string searchInput, int id);
    }
}
