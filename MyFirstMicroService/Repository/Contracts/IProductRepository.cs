using MyFirstMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMicroService.Repository.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductByID(int ProductId);
        Task CreateProduct(Product Product);
        Task DeleteProduct(int ProductId);
        Task EditProduct(Product Product);
    }
}
