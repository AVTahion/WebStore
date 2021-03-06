﻿using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Base.Interfases;

namespace WebStore.Domain.DTO.Products
{
    public class ProductDTO : INamedEntity, IOrderedEntity
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public int Order { get; set; }

        public decimal Price {get; set;}

        public string ImageUrl { get; set; }

        public BrandDTO Brand { get; set; }

        //public SectionDTO Section { get; set; }
    }
}
