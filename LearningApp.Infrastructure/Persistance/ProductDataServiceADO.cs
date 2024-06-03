using LearningApp.Application.InfrastructureInterfaces.Persistance;
using LearningApp.Domain.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LearningApp.Infrastructure.Persistance
{
    public class ProductDataServiceADO : IProductDataService
    {
        public Task<Product> AddProductIntoDatabase(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductsFromDBAByIdsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProductsFromDBAsync()
        {
            var products = new List<Product>();
            try
            {
                string connetionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=DemoApp;Integrated Security=True;";

                using (var conn = new SqlConnection(connetionString))
                {
                    var sql = "SELECT * FROM Products";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            var resultTable = new DataTable();
                            adapter.Fill(resultTable);
                            if (resultTable.Rows.Count > 0)
                            {
                                for (int i = 0; i < resultTable.Rows.Count; i++)
                                {
                                    var row = resultTable.Rows[i];
                                    var product = new Product();
                                    product.Id = Convert.ToInt32(row[0]);
                                    product.ProductName = row["ProductName"].ToString();
                                    products.Add(product);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return products;
        }
    }
}
