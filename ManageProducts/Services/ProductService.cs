using AutoMapper;
using ManageProducts.Models;
using ManageProducts.Models.Dto;
using ManageProducts.Repositories.Interfaces;
using ManageProducts.Services.Interfaces;

namespace ManageProducts.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> AddProduct(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            await _productRepository.AddProduct(product);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            var existingProduct = await _productRepository.GetProductById(id);
            _mapper.Map(updateProductDto, existingProduct); // Mapea las propiedades del DTO a la entidad existente
            await _productRepository.UpdateProduct(existingProduct);
        }
    }
}
