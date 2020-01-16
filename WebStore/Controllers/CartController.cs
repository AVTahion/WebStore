using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.infrastucture.interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService) => _cartService = cartService;

        public IActionResult Details() => 
            View(new CartOrderDetailsViewModel
            {
                CartViewModel = _cartService.TransformFromCart(),
                OrderViewModel = new OrderViewModel()
            });

        public IActionResult AddToCart(int id)
        {
            _cartService.AddToCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult DecrimentFromCart(int id)
        {
            _cartService.DecrementFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveFromCart(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemovAll()
        {
            _cartService.RemoveAll();
            return RedirectToAction("Details");
        }

        public IActionResult CheckOut(OrderViewModel model, [FromServices] IOrderService orderService)
        {
            if (!ModelState.IsValid)
                return View(nameof(Details), new CartOrderDetailsViewModel
                {
                    CartViewModel = _cartService.TransformFromCart(),
                    OrderViewModel = model
                });
            var order = orderService.CreateOrder(model, _cartService.TransformFromCart(), User.Identity.Name);

            _cartService.RemoveAll();

            return RedirectToAction("OrderConfirmed", new {id = order.Id});
        }

        public IActionResult OrderConfirmed(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }
    }
}