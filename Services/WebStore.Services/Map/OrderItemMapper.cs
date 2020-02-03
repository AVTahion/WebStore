using WebStore.Domain.DTO.Orders;
using WebStore.Domain.Entities;

namespace WebStore.Services.Map
{
    public static class OrderItemMapper
    {
        public static OrderItemDTO ToDTO(this OrderItem orderItem) => orderItem is null ? null : new OrderItemDTO
        {
            Id = orderItem.Id,
            Price = orderItem.Price,
            Quantity = orderItem.Quantity
        };

        public static OrderItem FromDTO(this OrderItemDTO orderItemDTO) => orderItemDTO is null ? null : new OrderItem
        {
            Id = orderItemDTO.Id,
            Price = orderItemDTO.Price,
            Quantity = orderItemDTO.Quantity
        };
    }
}
