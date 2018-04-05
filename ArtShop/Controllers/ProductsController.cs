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

            List<ProductViewModel> art;
            using (var connection = new SqlConnection(this.connectionString))
            {
                art = connection.Query<ProductViewModel>("select * from Paintings").ToList();
            }

            if (Request.Cookies["customerCookie"] == null)
            {
            var GuId = Guid.NewGuid();
            Response.Cookies.Append("customerCookie", GuId.ToString());
            }
            //else
            //{
            //    var cookie = Request.Cookies["customerCookie"];
            //}
            // Response.Cookies.Delete --för att ta bort cookien senare.

            return View(art);
        }

        [HttpPost]
        public IActionResult Index(CartViewModel model)
        {
            var cookie = Request.Cookies["customerCookie"];
            string sql = "INSERT INTO Cart (ProductId, Guid) VALUES (@Id, @cookie)";
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Execute(sql, new { model.Id, cookie }); 
            }

            return RedirectToAction("Index");
        }


    }
}