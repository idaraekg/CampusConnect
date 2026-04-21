using Microsoft.AspNetCore.Mvc;
using CampusConnect.Models;
using CampusConnect.Data;

namespace CampusConnect.Controllers
{
    public class AccountController : Controller
    {
        private readonly CampusConnectDbContext _context;

        public AccountController(CampusConnectDbContext context)
        {
            _context = context;
        }

        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    TempData["SuccessMessage"] = "Sign in successful!";
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid email or password.");
            }

            return View(model);
        }

        public IActionResult Join()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Join(JoinModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["FirstName"] = model.FirstName;
                TempData["LastName"] = model.LastName;

                return RedirectToAction("CreateAccount");
            }

            return View(model);
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccount(CreateAccountModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Email"] = model.Email;
                TempData["Password"] = model.Password;

                return RedirectToAction("SelectCategory");
            }

            return View(model);
        }

        public IActionResult SelectCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SelectCategory(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var firstName = TempData["FirstName"]?.ToString();
                var lastName = TempData["LastName"]?.ToString();
                var email = TempData["Email"]?.ToString();
                var password = TempData["Password"]?.ToString();

                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                    string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    return RedirectToAction("Join");
                }

                User user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Password = password,
                    Category = model.SelectedCategory
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Account created successfully!";
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}