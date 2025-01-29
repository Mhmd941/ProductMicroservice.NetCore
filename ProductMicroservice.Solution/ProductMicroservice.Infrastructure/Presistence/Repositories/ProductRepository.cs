using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Application.Interfaces;
using ProductMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Presistence.Repositories
{
    public class ProductRepository(ApplicationDbContext context):IProductRepository
    {

        private readonly ApplicationDbContext _context=context;

        public async Task AddAsync(Product product)=>await _context.Products.AddAsync(product);
       
        public async Task DeleteAsync(int id)
        {
            
            var product=await _context.Products.FindAsync(id);

            if (product is null) return;


            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Product>> GetAllAsync()=>await _context.Products.ToListAsync();





        public async Task<Product?> GetByIdAsync(int id)=> await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
       

        public async Task UpdateAsync(Product product)=> _context.Entry(product).State = EntityState.Modified;

    }
}
