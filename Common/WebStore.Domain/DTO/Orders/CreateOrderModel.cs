﻿using System.Collections.Generic;
using WebStore.Domain.ViewModels;

namespace WebStore.Domain.DTO.Orders
{
    public class CreateOrderModel
    {
        public OrderViewModel OrderViewModel { get; set; }

        public List<OrderItemDTO> OrderItems { get; set; }

    }
}
