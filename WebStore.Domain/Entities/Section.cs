using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfases;

namespace WebStore.Domain.Entities
{
    public class Section : NamedEntity, IOrderedEntity
    {
        public int Order { set; get; }
        public int? ParentId { set; get; }
    }
}
