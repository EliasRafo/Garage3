using Garage3.Core.Entities;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage3.Web.Models.ViewModels
{
    public class IndexViewModel2
    {
        public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();
        public FilterParams FilterParams { get; set; } = new FilterParams();

    }

    public class FilterParams
    {
        public string? Title { get; set; }
        public string? Genre { get; set; }

    }
}
