using LearningApp.Application.Services;
using Microsoft.Extensions.Options;

namespace LearningApp.Application.Test
{
    public class UnitTest1
    {
        [Fact]
        public async Task VerifyGetProducts()
        {
            var productService = new ProductService();
            var products = await productService.GetProductsAsync();
            Assert.Equal(1, products.Count);
        }
    }
}