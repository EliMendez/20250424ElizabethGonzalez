using ManageProducts.Models;
using ManageProducts.Models.Dto;

namespace ManageProducts.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> AddProduct(CreateProductDto createProductDto);
        Task UpdateProduct(int id, UpdateProductDto updateProductDto);
        Task DeleteProduct(int id);
    }
}
