using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Artshop.Project.Core.Repositories.Implementations
{
    public class CartRepository
    {
        private string ConnectionString;
        public CartRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public void PostToCart(int Id, string Cookie)
        {
            string sql = "INSERT INTO Cart (ProductId, Guid) VALUES (@Id, @cookie)";
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Execute(sql, new { Id, Cookie });
            }

        }
    }
}
