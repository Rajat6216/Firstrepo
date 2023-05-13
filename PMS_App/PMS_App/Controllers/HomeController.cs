using Microsoft.AspNetCore.Mvc;
using PMS_App.Models;
using System.Diagnostics;

namespace PMS_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Login()
        {
            ViewBag.ErrorMessage = null;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {

            if (email == "admin@gmail.com" && password == "password")
            {
                return RedirectToAction("Index", "Home");
            }
            else if(email == "rajat.r.kushwah@gmail.com" && password == "12345678" || email == "mohitchauhan@gmail.com" && password == "12345678")
            {
                return RedirectToAction("Index","Employee");
            }
           
            else
            {
                ViewBag.ErrorMessage = "Invalid email or password";
                return View();
            }
        }

        public IActionResult Registration()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Registration(string firstname, string lastname, string email, string password, string repeatPassword)
        {
            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(repeatPassword))
            {
                ViewBag.ErrorMessage = "Please fill out all fields";
                return View();
            }

            if (password != repeatPassword)
            {
                ViewBag.ErrorMessage = "Passwords do not match";
                return View();
            }

            return RedirectToAction("Login");
        }

        public IActionResult tables()
        {
            return View();
        }
        public IActionResult Charts()
        {
            return View();
        }
        public IActionResult Forget_Password()
        {
            return View();
        }

    }
}