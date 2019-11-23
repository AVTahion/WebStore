namespace WebStore.Domain.Entities.Base.Interfases
{
    /// <summary>
    /// Именованная сущность
    /// </summary>
    public interface INamedEntity : IBaseEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        string Name { set; get; }
    }
}
