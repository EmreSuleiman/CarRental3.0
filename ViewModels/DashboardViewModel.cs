using CarRental3._0.Models;

namespace CarRental3._0.ViewModels
{
    public class DashboardViewModel
    {
        public AppUser User { get; set; }
        public List<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
