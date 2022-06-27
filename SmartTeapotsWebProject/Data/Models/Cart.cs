using Microsoft.EntityFrameworkCore;
using SmartTeapotsWebProject.Data.DBContexts;

namespace SmartTeapotsWebProject.Data.Models
{
    public class Cart
    {
        private readonly SmartTeapotsDbContext _dbContext;

        public Cart(SmartTeapotsDbContext dbContext, string cartId)
        {
            _dbContext = dbContext;
            CartId = cartId;
        }

        public string CartId { get; set; }

        public List<CartItem> CartItems 
        { 
            get
            {
                return _dbContext.CartItems.Where(ci => ci.CartId == CartId).Include(st => st.SmartTeapot).ToList();
            }
        }

        public double TotalPrice
        {
            get
            {
                double total = default(int);

                foreach (var item in CartItems)
                {
                    total += item.Quantity * item.Price;
                }

                return total;
            }
        }

        public static Cart GetCart(IServiceProvider services)
        {
            var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            var context = services.GetService<SmartTeapotsDbContext>();

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", cartId);

            return new Cart(context!, cartId);
        }

        public void ClearCart()
        {
            var cartItems = _dbContext.CartItems.Where(t => t.CartId == CartId).ToList();
            _dbContext.RemoveRange(cartItems);
            _dbContext.SaveChanges();
        }

        public void AddToCart(SmartTeapot teapot)
        {
            var teapotToEdit = _dbContext.CartItems.FirstOrDefault(t => t.SmartTeapot.Id == teapot.Id && t.CartId == CartId);
            
            if (teapotToEdit != null)
            {
                teapotToEdit.Quantity += 1;
                _dbContext.CartItems.Update(teapotToEdit);
            }
            else
            {
                _dbContext.CartItems.Add(new CartItem
                {
                    CartId = CartId,
                    Price = teapot.Price,
                    SmartTeapot = teapot,
                    Quantity = 1
                });
            }

            _dbContext.SaveChanges();
        }
    }
}
