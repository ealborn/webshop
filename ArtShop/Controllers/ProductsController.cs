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

        public IActionResult Index()
        {

            List<ProductViewModel> art;
            art = this.productService.GetAll();
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
        
    }
}