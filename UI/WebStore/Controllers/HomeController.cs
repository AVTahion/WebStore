using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _Configuration;

        public HomeController(IConfiguration Configuration) => _Configuration = Configuration;
        
        public IActionResult Index() => View();

        public IActionResult ReadConfig() => Content(_Configuration["CustomData"]);

        public IActionResult Blog() => View();

        public IActionResult BlogSingle() => View();

        public IActionResult Cart() => View();

        public IActionResult Checkout() => View();

        public IActionResult ContactUs() => View();

        public IActionResult Login() => View();

        public IActionResult ProductDetails() => View();

        public IActionResult Shop() => View();

        public IActionResult Error404() => View();
    }
}