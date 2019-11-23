namespace WebStore.Domain.Entities.Base.Interfases
{
    /// <summary>
    /// именованая сущность
    /// </summary>
    public interface INamedEntities : IBaseEntities
    {
        /// <summary>
        /// Имя
        /// </summary>
        string Name { set; get; }
    }
}
