using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ArtShop.Controllers
{
    public class OrderRowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}