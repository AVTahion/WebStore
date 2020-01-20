using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Models;

namespace WebStore.infrastucture.interfaces
{
    public interface ICartService
    {
        void AddToCart(int Id);

        void DecrementFromCart(int Id);

        void RemoveFromCart(int Id);

        void RemoveAll();

        CartViewModel TransformFromCart();
    }
}
