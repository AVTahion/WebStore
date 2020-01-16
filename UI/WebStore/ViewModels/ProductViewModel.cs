using System;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Base.Interfases;

namespace WebStore.ViewModels
{
    public class ProductViewModel : INamedEntity, IOrderedEntity
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Order { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public  string Brand { get; set; }
    }
}
