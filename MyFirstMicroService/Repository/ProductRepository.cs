using Microsoft.EntityFrameworkCore;
using MyFirstMicroService.Context;
using MyFirstMicroService.Models;
using MyFirstMicroService.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMicroService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _dbContext;

        public ProductRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task DeleteProduct(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Product> GetProductByID(int productId)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == productId);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {
                return await _dbContext.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task CreateProduct(Product product)
        {
            await _dbContext.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

    }
}
