using Microsoft.AspNetCore.Mvc;
using SmartTeapotsWebProject.Data.Interfaces;
using SmartTeapotsWebProject.Data.Models;
using SmartTeapotsWebProject.Data.Repository;

namespace SmartTeapotsWebProject.Controllers
{
    public class CartController : Controller
    {
        private readonly IAllSmartTeapots _smartTeapots;
        private readonly Cart _cart;

        public CartController(IAllSmartTeapots smartTeapots, Cart cart)
        {
            _smartTeapots = smartTeapots;
            _cart = cart;
        }

        public IActionResult Index()
        {
            var cartItems = _cart.CartItems;
            return View(cartItems);
        }

        public IActionResult AddToCart(int id)
        {
            var teapot = _smartTeapots.GetSmartTeapotById(id);

            if (teapot != null)
            {
                _cart.AddToCart(teapot);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
