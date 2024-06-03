using LearningApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Application.InfrastructureInterfaces.Persistance
{
    public interface IProductDataService
    {
        public Task<List<Product>> GetProductsFromDBAsync();
        public Task<Product> AddProductIntoDatabase(Product product);
        public Task<Product> GetProductsFromDBAByIdsync(int id);
    }
}
