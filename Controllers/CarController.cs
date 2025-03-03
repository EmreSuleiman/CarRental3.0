using CarRental3._0.Data;
using CarRental3._0.Interfaces;
using CarRental3._0.Models;
using CarRental3._0.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarRental3._0.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICarRepository _carRepository;
        public CarController(ApplicationDbContext context, ICarRepository carRepository)
        {
            _context = context;
            _carRepository = carRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Car> cars = await _carRepository.GetAll();
            return View(cars);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Car car = await _carRepository.GetByIdAsync(id);
            return View(car);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Car car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }
            _carRepository.Add(car);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null) return View();
            var carVM = new EditCarViewModel
            {
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                DailyRate = car.DailyRate,
                Category = car.Category,
                Status = car.Status,
                Image = car.Image
            };
            return View(carVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCarViewModel carVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit car");
                return View("Edit", carVM);
            }
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            car.Brand = carVM.Brand;
            car.Model = carVM.Model;
            car.Year = carVM.Year;
            car.DailyRate = carVM.DailyRate;
            car.Category = carVM.Category;
            car.Status = carVM.Status;
            car.Image = carVM.Image;
            var result = _carRepository.Update(car);
            if (!result)
            {
                ModelState.AddModelError("", "Failed to save changes");
                return View("Edit", carVM);
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var carDetails = await _carRepository.GetByIdAsync(id);
            if (carDetails == null) return View();
            return View(carDetails);
        }
        [HttpPost, ActionName("DeleteCar")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var carDetails = await _carRepository.GetByIdAsync(id);
            if (carDetails == null) return View();
            _carRepository.Delete(carDetails);
            return RedirectToAction("Index");
        }
    }
}
