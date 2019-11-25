using WebStore.Domain.Entities.Base.Interfases;

namespace WebStore.Domain.Entities.Base
{
    /// <summary>
    /// Именованная сущность
    /// </summary>
    public abstract class NamedEntity : BaseEntity, INamedEntity
    {
        public string Name { get; set; }
    }


}

