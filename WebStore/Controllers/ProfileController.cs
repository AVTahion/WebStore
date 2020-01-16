using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.infrastucture.interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Orders([FromServices] IOrderService orderService) =>
            View(orderService
                .GetUserOrders(User.Identity.Name)
                .Select(order => new UserOrderViewModel
                {
                    Id = order.Id,
                    Name = order.Name,
                    Address = order.Address,
                    Phone = order.Phone,
                    TotalSum = order.OrderItems.Sum(item => item.Price * item.Quantity),
                    Date = order.Date
                }));
    }
}