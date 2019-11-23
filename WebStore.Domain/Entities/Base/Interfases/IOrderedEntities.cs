namespace WebStore.Domain.Entities.Base.Interfases
{
    /// <summary>
    /// Упорядочиваемая сущность
    /// </summary>
    public interface IOrderedEntities : IBaseEntities
    {
        /// <summary>
        /// Порядковый номер
        /// </summary>
        int Order { set; get; }
    }
}
