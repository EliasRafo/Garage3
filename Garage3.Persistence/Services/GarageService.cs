﻿using Garage3.Core.Entities;
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

        public async Task<Customer> IsMember(string ssn)
        {
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
        { // add customer information
            //var a = await _context.Garage.Where(s => s.Spots.Any(s=>s.Active==true));
        //.ThenInclude(v => v.VehicleType)
        //.ThenInclude(s => s.Garage)
        //.ToListAsync());

        //.Include(s => s.Vehicle)
        //.ThenInclude(v => v.VehicleType)
        //.ThenInclude(s => s.Garage)
        //.ToListAsync();
        //var a = await _context.Spot.Where(s => s.Active == true)
        //.Include(s => s.Vehicle)
        //.ThenInclude(v => v.VehicleType)
        //.Include(s => s.Vehicle.Customer)

        //.Include(s => s.Garage)

        //.ToListAsync();

            // Change to use of viewmodel+Select, discuss what data we need.
            return await _context.Spot.Where(s => s.Active == true)
        .Include(s => s.Vehicle)
        .ThenInclude(v => v.VehicleType)
        .Include(s => s.Vehicle.Customer)
        .Include(s => s.Garage)
        .ToListAsync();
        }
    }
}
