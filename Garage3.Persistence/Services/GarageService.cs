using Garage3.Core.Entities;
using Garage3.Core.Models;
using Garage3.Persistence.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<bool> AddVehicleType(VehicleType vehicleType)
        {
            var v = _context.VehicleType.Where(e => e.Type.StartsWith(vehicleType.Type)).FirstOrDefault();
            if (v is null)
            {
                _context.Add(vehicleType);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> ParkVehicle(ParkVihecle parkVihecle)
        {
            var v = _context.Spot.FirstOrDefault(e => e.Address == parkVihecle.Address);

            if (v is null) return false;
            if (v.Active == false)
            {
                v.Active = parkVihecle.Active;
                v.CheckIn = parkVihecle.CheckIn;
                v.CheckOut = parkVihecle.CheckOut;
                v.Address = parkVihecle.Address;
                v.VehicleId = parkVihecle.VehicleId;
                _context.Update(v);
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

        public async Task<IEnumerable<Spot>> GetAllSpots()
        {
            // Change to use of viewmodel+Select, discuss what data we need.
            return await _context.Spot.ToListAsync();
        }

        public async Task<Customer?> GetCustomerByID(int id)
        {
            return await _context.Customer.Include(s => s.Vehicles).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ICollection<Vehicle>> GetVehiclesByCustomerID(int id)
        {
            //Update with use of viewmodel.
            ICollection<Vehicle> vehicle = await _context.Vehicle.Where(s => s.Id == id).ToListAsync();
            return vehicle;
        }

        public async Task<Spot> GetSpotByID(int id)
        {
            return await _context.Spot.Where(s => s.Id == id)
                .Include(s => s.Vehicle)
                .ThenInclude(v => v.VehicleType)
                .Include(s => s.Vehicle.Customer)
                .Include(s => s.Garage).FirstOrDefaultAsync();
        }

        public async Task<VehicleType> GetVehicleTypeByType(string type)
        {
            return await _context.VehicleType.Where(t => t.Type == type)
                .FirstOrDefaultAsync();
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
            return await _context.Customer
                        .Include(s => s.Vehicles).ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByCustomerId(int id)
        {
            return await _context.Vehicle.Where(v => v.CustomerId == id)
                .Include(v => v.VehicleType).ToListAsync();
        }

        public async Task<bool> CreateCustomer(Customer customer)
        {
            var existingCustomer = await _context.Customer
                 .Where(c => c.SocialNum == customer.SocialNum)
                 .FirstOrDefaultAsync();

            if (existingCustomer is null)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<SelectListItem> GetGenres()
        {
            List < SelectListItem > x = new List<SelectListItem>();
            SelectListItem s1 = new SelectListItem() { Text = "First Name", Value = "1" };
            SelectListItem s2 = new SelectListItem() { Text = "Last Name", Value = "2" };

            x.Add(s1);
            x.Add(s2);
            return x;
        }

        public async Task<bool> VehicleExists(Vehicle vehicle)
        {
            return await _context.Vehicle.AnyAsync(e => e.RegNum == vehicle.RegNum);
        }

        public async Task<Vehicle> GetVehicleByID(int VehicleId)
        {  
            return await _context.Vehicle.Where(e => e.Id == VehicleId).Include(e=>e.Customer).FirstOrDefaultAsync();
        }

        public async Task<bool> VehicleExists(int VehicleId)
        {
            return await _context.Vehicle.AnyAsync(e => e.Id == VehicleId);
        }

        public async Task<bool> SpotFree(int SpotId)
        {
            return await _context.Spot.AnyAsync(e => e.Id == SpotId);
        }

        ////Handle search for the "skipped spots" and Reduce database calls.
        //public async Task<bool> SpotFree(int SpotId, int Vehiclesize)
        //{
        //    //Loop for vehicles Size
        //    for (int i = 0; i < Vehiclesize - 1; i++)
        //    {
        //        //Get data for spot-should be replaced with query for all spots
        //        Spot spot = await _context.Spot.FirstAsync(e => e.Id == (SpotId + i));
        //        if (spot.Active == true)
        //        {
        //            i = 0;
        //            SpotId = spot.Id+1;
        //            if (SpotId == 20)
        //            { return false;}
        //        }
        //        if (i == Vehiclesize - 1)
        //        { return true;}
        //    }
            
        //}

        public async Task<bool> VehicleIsParked(int VehicleId)
        {

            return await _context.Spot.AnyAsync(e => e.VehicleId == VehicleId);
        }


        public async Task<List<Vehicle>> SearchMatchAsync(string searchInput, int id)
        {

            ArgumentNullException.ThrowIfNull(searchInput, nameof(searchInput));


            int.TryParse(searchInput, out int searchInt);


            return await _context.Vehicle
                   .Where(s => s.CustomerId== id && 
                               (s.Brand == searchInput ||
                               s.Color == searchInput ||
                               s.Model == searchInput ||
                               s.RegNum == searchInput ||
                               s.WheelsNumber == searchInt ||
                               s.Id == searchInt ||
                               //Fix//Translate to type.
                               s.VehicleType.Type == searchInput)).Include(s=>s.Customer).Include(s=>s.VehicleType).ToListAsync();
        }

    }
}
