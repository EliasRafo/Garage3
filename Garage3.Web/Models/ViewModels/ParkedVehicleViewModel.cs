namespace Garage3.Web.Models.ViewModels
{
    public class ParkedVehicleViewModel
    {
        internal object Model;

        public object RegNum { get; internal set; }
        public object Brand { get; internal set; }
        public object Color { get; internal set; }
        public object WheelsNumber { get; internal set; }
    }
}