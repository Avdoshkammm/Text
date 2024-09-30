using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text.Application.Interfaces;
using Text.Domain.Entities;
using Text.Infrastructure.Data;

namespace Text.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly TestDBContext _db;
        public ProductRepository(TestDBContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _db.Products.ToListAsync();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _db.Products.FindAsync(id);
        }
        public async Task AddProductAsync(Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateProductAsync(Product product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteProductAsync(int id)
        {
            Product delProd = await _db.Products.FindAsync(id);
            if (delProd != null)
            {
                _db.Products.Remove(delProd);
                await _db.SaveChangesAsync();
            }
        }
    }
}
