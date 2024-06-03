using LearningApp.Application.InfrastructureInterfaces.Persistance;
using LearningApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Infrastructure.Persistance
{
    public class ProductDataServiceEF : IProductDataService
    {
        private readonly DemoAppDbContext _demoAppDbContext;
        public ProductDataServiceEF(DemoAppDbContext demoAppDbContext)
        {
            _demoAppDbContext = demoAppDbContext;
        }
        public async Task<Product> AddProductIntoDatabase(Product product)
        {
            try
            {
                var createdProduct = await _demoAppDbContext.Products.AddAsync(product);
                _demoAppDbContext.SaveChanges();
                return createdProduct.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> GetProductsFromDBAByIdsync(int id)
        {
            try
            {
                var product = await _demoAppDbContext.Products.SingleOrDefaultAsync(x => x.Id == id);
                if (product != null)
                {
                    return product;
                }
                else
                {
                    throw new Exception($"Product doesnot exist with ID : {id}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Product>> GetProductsFromDBAsync()
        {
            try
            {
                return await _demoAppDbContext.Products.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
