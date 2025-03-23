using AspNetCoreGeneratedDocument;
using CarRental3._0.Data;
using CarRental3._0.Interfaces;
using CarRental3._0.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarRental3._0.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<AppUser> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<List<Rental>> GetUserRentalsAsync(string userId)
        {
            return await _context.Rentals
                        .Include(r => r.Car) // Include the Car details
                        .Where(r => r.AppUserId == userId)
                        .ToListAsync();
        }
    }
}
