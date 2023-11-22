using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage3.Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string SocialNum { get; set; }

        //Navigation property
        public ICollection<Vehicle> Vehicles { get; set; }
        public object Membership { get; set; }
        public string Name { get; set; }
    }
}
