using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTeapotsWebProject.Data.Interfaces;
using SmartTeapotsWebProject.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace SmartTeapotsWebProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _orders;
        private readonly Cart _cart;

        public OrderController(IAllOrders orders, Cart cart)
        {
            _orders = orders;
            _cart = cart;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            if (_cart.CartItems.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(_cart);
        }

        [HttpPost]
        [Authorize]
        [ActionName("Checkout")]
        public IActionResult CheckoutAccept()
        {
            string? userName = User.Identity.Name;

            if(userName != null)
            {
                _orders.CreateAnOrder(userName);
                return RedirectToAction("Complete", "Order");
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Complete()
        {
            _cart.ClearCart();
            ViewBag.Message = "Order successfully completed!";
            return View();
        }
    }
}
