using CarRental3._0.Data;
using CarRental3._0.Interfaces;
using CarRental3._0.Models;
using CarRental3._0.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarRental3._0.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(IDashboardRepository dashboardRepository, UserManager<AppUser> userManager)
        {
            _dashboardRepository = dashboardRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User); // Get the current user's ID
            var user = await _dashboardRepository.GetUserByIdAsync(userId);
            var rentals = await _dashboardRepository.GetUserRentalsAsync(userId);

            var dashboardViewModel = new DashboardViewModel
            {
                User = user,
                Rentals = rentals
            };

            return View(dashboardViewModel);
        }
    }
}
