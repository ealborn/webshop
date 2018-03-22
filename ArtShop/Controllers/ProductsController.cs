using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ArtShop.Models;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace ArtShop.Controllers
{
    //using ArtShop.Models;
    

    public class ProductsController : Controller
    {
        private static List<ProductViewModel> art = new List<ProductViewModel>();
        private readonly string connectionString;

        public ProductsController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public IActionResult Index()
        {
            //return View(new List<ProductViewModel>());//ersätt med resultat från databasen

            List<ProductViewModel> news;
            using (var connection = new SqlConnection(this.connectionString))
            {
                news = connection.Query<ProductViewModel>("select * from Paintings").ToList();
            }

            return View(news);



        }
    }
}