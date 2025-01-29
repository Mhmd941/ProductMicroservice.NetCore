using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Application.DTOs;
using ProductMicroservice.Application.Interfaces;

namespace ProductMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {

        private readonly IProductService _productService=productService;


        [HttpGet]
        public async Task<IActionResult> GetAll()=>Ok(await _productService.GetAllProductsAsync());

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var product=await _productService.GetProductByIdAsync(id);


            return product is not null ? Ok(product) : NotFound();


        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto)
        {

            await _productService.AddProductAsync(productDto);

            return Ok("Product Created Successfully");
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductDto updateProductDto)
        {

            var existingProduct = await _productService.GetProductByIdAsync(id);
            if (existingProduct is null)
                return NotFound($"Product with ID {id} not found.");

            await _productService.UpdateProductAsync(updateProductDto);
            return NoContent();

        }
        
    }
}
