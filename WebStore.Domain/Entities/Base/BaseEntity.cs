using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Base.Interfases;

namespace WebStore.Domain.Entities.Base
{
    /// <summary>
    /// Сущность
    /// </summary>
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { set; get; }
    }
}

