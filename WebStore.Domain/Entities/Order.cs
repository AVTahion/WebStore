using System;
using System.Collections.Generic;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Domain.Entities
{
    public class Order : NamedEntity
    {
        public virtual User User { get; set; }

        public string Phone { get; set; }

        public  string Addres { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}