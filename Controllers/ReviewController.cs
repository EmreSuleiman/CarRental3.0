using CarRental3._0.Data;
using CarRental3._0.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental3._0.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ReviewController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Review review)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login", "Account");
                }

                review.UserId = user.Id;
                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(review);
        }

        public IActionResult GetTopReviews()
        {
            var topReviews = _context.Reviews
                .Include(r => r.User)
                .Where(r => r.Rating == 5)
                .OrderByDescending(r => r.CreatedAt)
                .Take(3)
                .ToList();

            return Json(topReviews);
        }
    }
}
