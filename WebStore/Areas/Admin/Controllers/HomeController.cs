using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.Administrator)]
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        
        public IActionResult UI() => View();

        public IActionResult Tab_panel() => View();

        public IActionResult Chart() => View();

        public IActionResult Table() => View();

        public IActionResult Form() => View();

        public IActionResult Login() => View();

        public IActionResult Registeration() => View();

        public IActionResult Blank() => View();
    }
}