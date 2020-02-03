using WebStore.Domain.DTO.Products;

namespace WebStore.Services.Map
{
    public static class ProductMapper
    {
        public static ProductDTO ToDTO(this Domain.Entities.Product product) => product is null ? null : new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Order = product.Order,
            ImageUrl = product.ImageUrl,
            Price = product.Price,
            Brand = product.Brand.ToDTO()
        };

        public static Domain.Entities.Product FromDTO(this ProductDTO productDTO) => productDTO is null ? null : new Domain.Entities.Product
        {
            Id = productDTO.Id,
            Name = productDTO.Name,
            Order = productDTO.Order,
            ImageUrl = productDTO.ImageUrl,
            Price = productDTO.Price,
            Brand = productDTO.Brand.FromDTO(),
            BrandId = productDTO.Brand?.Id
        };
    }
}
