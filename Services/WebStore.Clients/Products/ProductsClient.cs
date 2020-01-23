using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebStore.Clients.Base;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;
using WebStore.infrastucture.interfaces;

namespace WebStore.Clients.Products
{
    public class ProductsClient : BaseClient, IProductData
    {
        public ProductsClient(IConfiguration config) : base(config, "api/products") { }

        public IEnumerable<Brand> GetBrands() => Get<List<Brand>>($"{_ServiceAddress}/brands");

        public ProductDTO GetProductById(int id) => Get<ProductDTO>($"{_ServiceAddress}/{id}");

        public IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null) => Post(_ServiceAddress, Filter)
            .Content
            .ReadAsAsync<List<ProductDTO>>()
            .Result;

        public IEnumerable<Section> GetSections() => Get<List<Section>>($"{_ServiceAddress}/sections");
    }
}
