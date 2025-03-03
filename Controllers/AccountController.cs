using CarRental3._0.Data;
using CarRental3._0.Models;
using CarRental3._0.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarRental3._0.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
            {
                // If the model state is invalid, return the view with validation errors
                return View(loginVM);
            }

            // Find the user by email
            var user = await _userManager.FindByEmailAsync(loginVM.Email);

            if (user != null)
            {
                // Check if the password is correct
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);

                if (passwordCheck)
                {
                    // Sign in the user
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, isPersistent: false, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        // Redirect to the home page or a specific page after successful login
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            // If login fails, display an error message
            TempData["Error"] = "Грешна информация. Моля опитайте отново.";
            return View(loginVM);
        }

        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.Email);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use.";
                return View(registerVM);
            }

            var newUser = new AppUser()
            {
                Email = registerVM.Email,
                UserName = registerVM.Email, // Ensure UserName is set
                FullName = registerVM.FullName,
                Role = UserRoles.User
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

                // Log the successful registration
                Console.WriteLine($"User {newUser.Email} registered successfully.");

                // Sign in the user after registration
                await _signInManager.SignInAsync(newUser, isPersistent: false);

                // Redirect to a success page or home page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Log errors
                foreach (var error in newUserResponse.Errors)
                {
                    Console.WriteLine($"Error during registration: {error.Description}");
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(registerVM);
            }
        }
        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModel registerVM)
        //{
        //    if (!ModelState.IsValid) return View(registerVM);
        //    var user = await _userManager.FindByEmailAsync(registerVM.Email);
        //    if(user != null)
        //    {
        //        TempData["Error"] = "This email address in already in user";
        //        return View(registerVM);
        //    }
        //    var newUser = new AppUser()
        //    {
        //        Email = registerVM.Email,
        //        UserName = registerVM.Email
        //    };
        //    var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

        //    if (newUserResponse.Succeeded) await _userManager.AddToRoleAsync(newUser, UserRoles.User);

        //    return View("Views/Home/Index.cshtml");
        //}
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Car");
        }
    }
}
