using AutoMapper;
using ProductMicroservice.Application.DTOs;
using ProductMicroservice.Application.Interfaces;
using ProductMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Application.Services
{
    public class ProductService(IMapper mapper,IProductRepository productRepository) : IProductService
    {
        private readonly IMapper _mapper=mapper;
        private readonly IProductRepository _repository=productRepository;
        public async Task AddProductAsync(CreateProductDto productDto)
        {
            

            var product=_mapper.Map<Product>(productDto);

            await _repository.AddAsync(product);
        }

        public async Task DeleteProductAsync(int id)=>await _repository.DeleteAsync(id);
        
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {

            var products = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProductDto>>(products);  
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product=await _repository.GetByIdAsync(id);

            return _mapper.Map<ProductDto?>(product);
        }

        public async Task UpdateProductAsync(UpdateProductDto productDto)
        {
            var product=_mapper.Map<Product>(productDto);

            await _repository.UpdateAsync(product);
        }
    }
}
