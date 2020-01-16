using WebStore.Models;

namespace WebStore.ViewModels
{
    public class CartOrderDetailsViewModel
    {
        public CartViewModel CartViewModel { get; set; }

        public OrderViewModel OrderViewModel { get; set; }
    }
}