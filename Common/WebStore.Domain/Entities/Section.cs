using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfases;

namespace WebStore.Domain.Entities
{
    [Table("Sections")]
    public class Section : NamedEntity, IOrderedEntity
    {
        public int Order { set; get; }
        public int? ParentId { set; get; }

        [ForeignKey(nameof(ParentId))]
        public virtual Section ParentSections { get; set; }

        public virtual ICollection<Domain.Entities.Product> Products { get; set; }
    }
}
