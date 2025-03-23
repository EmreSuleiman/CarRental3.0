using CarRental3._0.Models;

namespace CarRental3._0.ViewModels
{
    public class AdminDashboardViewModel
    {
        public List<Rental> Rentals { get; set; } = new List<Rental>();
        public List<UserViewModel> Users { get; set; } = new List<UserViewModel>();
        public List<UserViewModel> BlacklistedUsers { get; set; } = new List<UserViewModel>();
    }

    public class UserViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsBlacklisted { get; set; }
    }
}
