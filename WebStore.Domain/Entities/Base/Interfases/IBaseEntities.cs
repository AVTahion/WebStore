using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entities.Base.Interfases
{
    /// <summary>
    /// Сущность
    /// </summary>
    public interface IBaseEntities
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        int Id { set; get; }
    }
}
