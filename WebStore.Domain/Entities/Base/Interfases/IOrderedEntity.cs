namespace WebStore.Domain.Entities.Base.Interfases
{
    /// <summary>
    /// Упорядочиваемая сущность
    /// </summary>
    public interface IOrderedEntity : IBaseEntity
    {
        /// <summary>
        /// Порядковый номер
        /// </summary>
        int Order { set; get; }
    }
}
