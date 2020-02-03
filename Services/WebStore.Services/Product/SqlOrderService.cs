using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebStore.DAL.Context;
using WebStore.Domain.DTO.Orders;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Identity;
using WebStore.infrastucture.interfaces;
using WebStore.Services.Map;

namespace WebStore.Services.Product
{
    public class SqlOrderService : IOrderService
    {
        private readonly WebStoreContext _db;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<SqlOrderService> _logger;

        public SqlOrderService(WebStoreContext db, UserManager<User> userManager, ILogger<SqlOrderService> Logger)
        {
            _db = db;
            _userManager = userManager;
            _logger = Logger;
        }

        public OrderDTO CreateOrder(CreateOrderModel OrderModel, string UserName)
        {
            var user = _userManager.FindByNameAsync(UserName).Result;
            _logger.LogInformation($"Пользователь {user.UserName} оформляет заказ");

            using (var transaction = _db.Database.BeginTransaction())
            {
                var order = new Order
                {
                    Name = OrderModel.OrderViewModel.Name,
                    Address = OrderModel.OrderViewModel.Address,
                    Phone = OrderModel.OrderViewModel.Phone,
                    Date = DateTime.Now,
                    User = user
                };
                _logger.LogInformation($"Указанный получатель заказа: {order.Name}, адрес доставки: {order.Address}, телефон для связи: {order.Phone}");
                _db.Orders.Add(order);

                foreach (var item in OrderModel.OrderItems)
                {
                    var product = _db.Products.FirstOrDefault(p => p.Id == item.Id);
                    if (product is null)
                    {
                        _logger.LogError($"Товар с id {item.Id} отсутствует в БД");
                        throw new InvalidOperationException($"Товар с ID:{item.Id} отсутствует в БД");
                    }

                    var order_item = new OrderItem
                    {
                        Order = order,
                        Price = product.Price,
                        Quantity = item.Quantity,
                        Product = product
                    };

                    _db.OrderItems.Add(order_item);
                    _logger.LogInformation($"В заказ добавлен товар: {product.Name} - {item.Quantity} шт.");
                }

                _db.SaveChanges();
                transaction.Commit();

                _logger.LogInformation($"Заказ {order.Id} пользователя {user.UserName} оформлен", order);

                return order.ToDTO();
            }
        }

        public OrderDTO GetOrderById(int Id) => _db.Orders
                .Include(order => order.OrderItems)
                .FirstOrDefault(order => order.Id == Id)
                .ToDTO();

        public IEnumerable<OrderDTO> GetUserOrders(string UserName) => _db.Orders
            .Include(order => order.User)
            .Include(order => order.OrderItems)
            .Where(order => order.User.UserName == UserName)
            .ToArray()
            .Select(OrderMapper.ToDTO);
    }
}
