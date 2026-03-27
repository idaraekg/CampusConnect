using Microsoft.AspNetCore.Mvc;
using CampusConnect.Models;

namespace CampusConnect.Controllers
{
    public class AccountController : Controller
    {
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
                ViewBag.Message = "Sign in successful!";
                return View("Success");
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
                ViewBag.Message = "Account created successfully!";
                return View("Success");
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}