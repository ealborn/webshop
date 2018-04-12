using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data.SqlClient;

namespace Artshop.Project.Core.Repositories.Implementations
{
    public class OrderRepository
    {
        private string ConnectionString;

        public OrderRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public void PostToOrder(string Firstname, string Lastname, string Email, int Phone, string Address, int Zipcode)
        {
            string sql = "INSERT INTO Orders (Firstname, LastName, Email, Phone, Address, Zipcode) VALUES (@Firstname, @Lastname, @Email, @Phone, @Address, @Zipcode)";

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Execute(sql, new { Firstname, Lastname, Email, Phone, Address, Zipcode });
            }
        }
    }
}
