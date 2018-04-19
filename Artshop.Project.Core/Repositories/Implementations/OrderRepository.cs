using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using ArtShop.Project.Core.Models;

namespace Artshop.Project.Core.Repositories.Implementations
{
    public class OrderRepository
    {
        private readonly OrderRepository checkoutRepository;

        public OrderRepository(OrderRepository orderRepository)
        {
            this.checkoutRepository = orderRepository;
        }

        private string ConnectionString;

        public OrderRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public void PostToOrder(string Firstname, string Lastname, string Email, string Address, int Zipcode, string cookie)
        {
            string sql = @"INSERT INTO Orders 
                            (Firstname, LastName, Email, Address, Zipcode, Guid) 
                          VALUES 
                             (@Firstname, @Lastname, @Email, @Address, @Zipcode, @cookie)";

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Execute(sql, new { Firstname, Lastname, Email, Address, Zipcode, cookie });
            }
        }

        public void DeleteCart(string cookie)
        {
            string sql2 = "DELETE FROM Cart WHERE Guid = @cookie";
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Execute(sql2, new { cookie });
            }
        }
    }
}
