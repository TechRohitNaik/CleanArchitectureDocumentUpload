// See https://aka.ms/new-console-template for more information
using LearningApp.Application.Services;

Console.WriteLine("Hello, World!");
var productService = new ProductService();
var products = await productService.GetProductsAsync();
if (products != null & products.Count > 0)
{
    foreach (var product in products)
    {
        Console.WriteLine($"Product ID : {product.Id} Product Name : {product.ProductName}");
    }
}