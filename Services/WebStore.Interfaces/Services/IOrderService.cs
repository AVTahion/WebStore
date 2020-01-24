using System.Collections.Generic;
using WebStore.Domain.DTO.Orders;

namespace WebStore.infrastucture.interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDTO> GetUserOrders(string UserName);

        OrderDTO GetOrderById(int Id);

        OrderDTO CreateOrder(CreateOrderModel OrderModel, string UserName);
    }
}
