using ArtShop.Project.Core.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        public List<CartViewModel> GetAll()
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                return connection.Query<CartViewModel>(
                        @"SELECT Paintings.Id, Paintings.Title, Paintings.Image, Paintings.Price, Cart.* 
                                FROM Paintings
                                JOIN Cart ON Cart.ProductId = Paintings.Id;").ToList();
            }

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
