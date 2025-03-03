using CarRental3._0.Models;

namespace CarRental3._0.Interfaces
{
    public interface IDashboardRepository
    {
        Task<AppUser> GetUserByIdAsync(string userId);
        Task<List<Rental>> GetUserRentalsAsync(string userId);
    }
}
