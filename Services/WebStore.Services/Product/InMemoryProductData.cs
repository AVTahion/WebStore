﻿using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.Entities;
using WebStore.infrastucture.interfaces;
using WebStore.Services.Database;

namespace WebStore.Services.Product
{
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Brand> GetBrands() => TestData.Brands;

        public Domain.Entities.Product GetProductById(int id) => TestData.Products.FirstOrDefault(p => p.Id == id);

        public IEnumerable<Domain.Entities.Product> GetProducts(ProductFilter Filter = null)
        {
            var query = TestData.Products;

            if (Filter?.SectionId != null)
                query = query.Where(product => product.SectionId == Filter.SectionId);

            if (Filter?.BrandId != null)
                query = query.Where(product => product.BrandId == Filter.BrandId);

            return query;
        }

        public IEnumerable<Section> GetSections() => TestData.Sections;
    }
}