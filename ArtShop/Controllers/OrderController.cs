using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using ArtShop.Models;
using Artshop.Project.Core.Repositories.Implementations;
using Artshop.Project.Core.Services;
using ArtShop.Project.Core.Models;
using Microsoft.AspNetCore.Http;

namespace ArtShop.Controllers
{
    public class OrderController : Controller
    {
        private static List<OrderViewModel> checkout = new List<OrderViewModel>();
        private readonly string connectionString;
        private OrderService orderService;

        public OrderController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.orderService = new OrderService(new OrderRepository(this.connectionString), new CartRepository(this.connectionString));
        }

        public IActionResult Index()
        {
            var cartId = Request.Cookies["customerCookie"];
            var Cart = this.orderService.GetAll(cartId);
            return View(Cart);
        }

        [HttpPost]
        public IActionResult Index(OrderViewModel model, string cookie, string customerCookie)
        {
            this.orderService.PostToOrder(model.Firstname, model.Lastname, model.Email, model.Address, model.Zipcode, Request.Cookies["customerCookie"]);

            cookie = Request.Cookies["customerCookie"];
            this.orderService.DeleteCart(cookie);

            return RedirectToAction("Index");
        }
    }
}