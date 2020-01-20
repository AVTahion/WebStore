using WebStore.Domain.Models;

namespace WebStore.Domain.ViewModels
{
    public class CartOrderDetailsViewModel
    {
        public CartViewModel CartViewModel { get; set; }

        public OrderViewModel OrderViewModel { get; set; }
    }
}