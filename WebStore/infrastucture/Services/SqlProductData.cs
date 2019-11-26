using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.infrastucture.interfaces;

namespace WebStore.infrastucture.Services
{
    public class SqlProductData : IProductData //Unit of work
    {
        private readonly WebStoreContext _bd;

        public SqlProductData(WebStoreContext bd) => _bd = bd;

        public IEnumerable<Brand> GetBrands() => _bd.Brands.Include(brand => brand.Products).AsEnumerable();

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            IQueryable<Product> query = _bd.Products;

            if (Filter?.BrandId != null)
                query = query.Where(product => product.BrandId == Filter.BrandId);

            if (Filter?.SectionId != null) 
                query = query.Where(product => product.SectionId == Filter.SectionId);

            return query.AsEnumerable();
        }

        public IEnumerable<Section> GetSections() => _bd.Sections.Include(section => section.Products).AsEnumerable();
    }
}
