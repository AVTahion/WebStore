using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Base.Interfases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Domain.Entities.Base
{
    /// <summary>
    /// Сущность
    /// </summary>
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
    }
}

