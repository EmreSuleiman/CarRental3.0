using CarRental3._0.Data;
using Microsoft.AspNetCore.Mvc;

namespace CarRental3._0.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
