using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using ArtShop.Project.Core.Models;
using Artshop.Project.Core.Repositories.Implementations;
using Artshop.Project.Core.Services;

namespace ArtShop.Controllers
{
    public class ProductsController : Controller
    {
        private static List<ProductViewModel> art = new List<ProductViewModel>();

        private readonly ProductService productService;

        public ProductsController(IConfiguration configuration)
        {
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

            return View(art);
        }

    }
}