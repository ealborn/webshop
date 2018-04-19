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
using Dapper;
using ArtShop.Models;
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
            //this.connectionString = configuration.GetConnectionString("ConnectionString");
            //checkoutService = new OrderService(new OrderRepository(this.connectionString));
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.orderService = new OrderService(new OrderRepository(this.connectionString), new CartRepository(this.connectionString));
        }

        public IActionResult Index()
        {
            var cartId = Request.Cookies["customerCookie"];
            var Cart = this.orderService.GetAll(cartId);
            //var cart = this.checkoutService.GetAll();
            //return View(cart);
            return View(Cart);
        }

        [HttpPost]
        public IActionResult Index(OrderViewModel model)
        {
            //var cookie = Request.Cookies["customerCookie"];
            this.orderService.PostToOrder(model.Firstname, model.Lastname, model.Email, model.Phone, model.Address, model.Zipcode, Request.Cookies["customerCookie"]);
            return RedirectToAction("Index");
        }
    }
}