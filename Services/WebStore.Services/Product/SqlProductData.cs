using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;
using WebStore.infrastucture.interfaces;

namespace WebStore.Services.Product
{
    public class SqlProductData : IProductData //Unit of work
    {
        private readonly WebStoreContext _bd;

        public SqlProductData(WebStoreContext bd) => _bd = bd;

        public IEnumerable<Brand> GetBrands() => _bd.Brands
            .Include(brand => brand.Products)
            .AsEnumerable();

        public ProductDTO GetProductById(int id)
        {
             var product = _bd.Products
                        .Include(p => p.Brand)
                        .Include(p => p.Section)
                        .FirstOrDefault(p => p.Id == id);
            
            return product is null ? null : new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Order = product.Order,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Brand = product.Brand is null ? null : new BrandDTO
                {
                    Id = product.Brand.Id,
                    Name = product.Brand.Name
                }
            };
        }

        public IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null)
        {
            IQueryable<Domain.Entities.Product> query = _bd.Products;

            if (Filter?.BrandId != null)
                query = query.Where(product => product.BrandId == Filter.BrandId);

            if (Filter?.SectionId != null)
                query = query.Where(product => product.SectionId == Filter.SectionId);

            return query
                .AsEnumerable()
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    Brand = p.Brand is null ? null : new BrandDTO
                    {
                        Id = p.Brand.Id,
                        Name = p.Brand.Name
                    }
                });
        }

        public IEnumerable<Section> GetSections() => _bd.Sections
            .Include(section => section.Products)
            .AsEnumerable();
    }
}
