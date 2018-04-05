using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using ArtShop.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ArtShop.Controllers
{
    public class CartController : Controller
    {
        private static List<CartViewModel> Cart = new List<CartViewModel>();
        private readonly string connectionString;

        public CartController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
        }


        public IActionResult Index()
        {

            List<CartViewModel> Cart;
            using (var connection = new SqlConnection(this.connectionString))
            {
                Cart = connection.Query<CartViewModel>(
                        @"SELECT Paintings.Id, Paintings.Title, Paintings.Image, Paintings.Price, Cart.* 
                                FROM Paintings
                                JOIN Cart ON Cart.ProductId = Paintings.Id;").ToList();
            }

            return View(Cart);
        }

    }
}