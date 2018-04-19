using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Extensions.Configuration;
using Artshop.Project.Core.Services;
using Artshop.Project.Core.Repositories.Implementations;
using ArtShop.Project.Core.Models;

namespace ArtShop.Controllers
{
    public class ProductsController : Controller
    {
        private static List<ProductViewModel> art = new List<ProductViewModel>();
        private readonly ProductService productService;
        private string connectionString;

        public ProductsController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.productService = new ProductService(
                new ProductRepository(
                    configuration.GetConnectionString("ConnectionString")));
        }

        private string GetOrCreateCookie()
        {
            if (this.Request.Cookies.ContainsKey("customerCookie"))
            {
                return this.Request.Cookies["customerCookie"];
            }
            var cookie = Guid.NewGuid().ToString();
            this.Response.Cookies.Append("customerCookie", cookie.ToString());
            return cookie;
        }


        public IActionResult Index()
        {

            List<ProductViewModel> art;
            art = this.productService.GetAll();

            return View(art);
        }

    }
}