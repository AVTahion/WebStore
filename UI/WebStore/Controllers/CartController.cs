using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.DTO.Orders;
using WebStore.Domain.ViewModels;
using WebStore.infrastucture.interfaces;

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

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CheckOut(OrderViewModel model, [FromServices] IOrderService orderService)
        {
            if (!ModelState.IsValid)
                return View(nameof(Details), new CartOrderDetailsViewModel
                {
                    CartViewModel = _cartService.TransformFromCart(),
                    OrderViewModel = model
                });

            var create_order_model = new CreateOrderModel
            {
                OrderViewModel = model,
                OrderItems = _cartService.TransformFromCart().Items
                    .Select(item => new OrderItemDTO
                    {
                        Id = item.Key.Id,
                        Price = item.Key.Price,
                        Quantity = item.Value
                    })
                    .ToList()
            };

            var order = orderService.CreateOrder(create_order_model, User.Identity.Name);

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