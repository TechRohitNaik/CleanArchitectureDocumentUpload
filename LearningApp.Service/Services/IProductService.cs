using LearningApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Service.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetProductsAsync();
        public Task<Product> AddProduct(Product product);
        public Task<Product> GetProductByIdAsync(int id);
    }
}
