using AutoMapper;
using ManageProducts.Models;
using ManageProducts.Models.Dto;

namespace ManageProducts.Services.Mappers
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDto>(); // Mapeo de Product a ProductDto
            CreateMap<CreateProductDto, Product>(); // Mapeo de CreateProductDto a Product
            CreateMap<UpdateProductDto, Product>(); // Mapeo de UpdateProductDto a Product
        }
    }
}
