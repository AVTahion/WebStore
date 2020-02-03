using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IConfiguration _Configuration;

        //public HomeController(IConfiguration Configuration) => _Configuration = Configuration;
        
        public IActionResult Index() => View();

        public IActionResult Blog() => View();

        public IActionResult BlogSingle() => View();

        public IActionResult ContactUs() => View();

        public IActionResult Error404() => View();

        public IActionResult ErrorStatus(string Id)
        {
            switch (Id)
            {
                default:
                    return Content($"Статусный код {Id}");
                case "404":
                    return RedirectToAction(nameof(Error404));
            }
        }

        public IActionResult ThrowException() => throw new ApplicationException("Тестовая ошибка в программе");
    }
}