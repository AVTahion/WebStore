using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.ViewModels;

namespace WebStore.Domain.Models
{
    public class CartViewModel
    {
        public Dictionary<ProductViewModel, int> Items { get; set; } = new Dictionary<ProductViewModel, int>();

        public int ItemsCoumt => Items?.Sum(item => item.Value) ?? 0;
    }
}
