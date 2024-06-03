using LearningApp.Application.InfrastructureInterfaces.Persistance;
using LearningApp.Domain.Models;
using LearningApp.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDataService _productDataService;
        public ProductService(IProductDataService productDataService)
        {
            _productDataService = productDataService;
        }
        public ProductService()
        {

        }
        public async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                return await _productDataService.GetProductsFromDBAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                var createdProduct = await _productDataService.AddProductIntoDatabase(product);
                return createdProduct;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await _productDataService.GetProductsFromDBAByIdsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
