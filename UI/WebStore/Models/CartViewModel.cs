using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Internal;
using WebStore.ViewModels;

namespace WebStore.Models
{
    public class CartViewModel
    {
        public Dictionary<ProductViewModel, int> Items { get; set; } = new Dictionary<ProductViewModel, int>();

        public int ItemsCoumt => Items?.Sum(item => item.Value) ?? 0;
    }
}
