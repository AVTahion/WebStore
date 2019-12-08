using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.Administrator)]
    public class HomeController : Controller
    {
        [MenuItemElements(" Dashboard", "fa fa-dashboard fa-3x")]
        public IActionResult Index() => View();
        
        [MenuItemElements(" UI Elements", "fa fa-desktop fa-3x")]
        public IActionResult UI() => View();

        [MenuItemElements(" Tabs & Panels", "fa fa-qrcode fa-3x")]
        public IActionResult Tab_panel() => View();

        [MenuItemElements(" Morris Charts", "fa fa-bar-chart-o fa-3x")]
        public IActionResult Chart() => View();

        [MenuItemElements(" Table Examples", "fa fa-table fa-3x")]
        public IActionResult Table() => View();

        [MenuItemElements(" Forms", "fa fa-edit fa-3x")]
        public IActionResult Form() => View();

        [MenuItemElements(" Blank Page", "fa fa-square-o fa-3x")]
        public IActionResult Blank() => View();
    }
}