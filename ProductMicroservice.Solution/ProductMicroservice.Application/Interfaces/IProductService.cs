using ProductMicroservice.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Application.Interfaces
{
    public interface IProductService
    {

        Task<IEnumerable<ProductDto>> GetAllProductsAsync();

        Task<ProductDto?> GetProductByIdAsync(int id);

        Task AddProductAsync(CreateProductDto productDto);

        Task UpdateProductAsync(UpdateProductDto productDto);

        Task DeleteProductAsync(int id); 
    }
}
