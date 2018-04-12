using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Artshop.Project.Core.Repositories.Implementations;
using Artshop.Project.Core.Services;
using ArtShop.Project.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ArtShop.Controllers
{
    public class OrderController : Controller
    {
        private static List<OrderViewModel> checkout = new List<OrderViewModel>();
        private readonly string connectionString;
        private OrderService checkoutService;

        public OrderController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            checkoutService = new OrderService(new OrderRepository(this.connectionString));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(OrderViewModel model)
        {
            var cookie = Request.Cookies["customerCookie"];
            this.checkoutService.PostToOrder(model.Firstname);
            return RedirectToAction("Index");
        }
    }
}