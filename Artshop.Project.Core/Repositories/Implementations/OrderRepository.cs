using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using ArtShop.Project.Core.Models;
using System.Linq;

namespace Artshop.Project.Core.Repositories.Implementations
{
    public class OrderRepository
    {
        private string ConnectionString;

        public OrderRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        //public List<CartViewModel> GetAll()
        //{
        //    using (var connection = new SqlConnection(this.ConnectionString))
        //    {
        //        return connection.Query<CartViewModel>(
        //        @"SELECT Paintings.Id, Paintings.Title, Paintings.Image, Paintings.Price, Cart.* 
        //                FROM Paintings
        //                JOIN Cart ON Cart.ProductId = Paintings.Id;").ToList();
        //    }

        //}

        public void PostToOrder(string Firstname, string Lastname, string Email, int Phone, string Address, int Zipcode, string cookie)
        {
            string sql = @"INSERT INTO Orders (Firstname, LastName, Email, Phone, Address, Zipcode, Guid) 
                            VALUES (@Firstname, @Lastname, @Email, @Phone, @Address, @Zipcode, @cookie)";

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Execute(sql, new { Firstname, Lastname, Email, Phone, Address, Zipcode, cookie });
            }
        }
    }
}
