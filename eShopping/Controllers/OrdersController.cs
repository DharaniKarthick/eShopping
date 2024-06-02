using Microsoft.AspNetCore.Mvc;
using eShopping.Models;
using eShopping.Work.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopping.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly ProductManager _productManager;
        public IActionResult Checkout()
        {
            return View();
        }
    }
}
