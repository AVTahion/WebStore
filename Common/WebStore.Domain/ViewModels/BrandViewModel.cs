﻿using WebStore.Domain.Entities.Base.Interfases;

namespace WebStore.Domain.ViewModels
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Order { get; set; }
    }
}
