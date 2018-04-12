using ArtShop.Project.Core.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Artshop.Project.Core.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private string ConnectionString; 
        public ProductRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<ProductViewModel> GetAll()
        {
            
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                return connection.Query<ProductViewModel>("select * from Paintings").ToList();
            }
        }
    }
}
