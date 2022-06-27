using SmartTeapotsWebProject.Data.Interfaces;
using SmartTeapotsWebProject.Data.Models;
using SmartTeapotsWebProject.Data.DBContexts;

namespace SmartTeapotsWebProject.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly SmartTeapotsDbContext _dbContext;
        private readonly Cart _cart;

        public OrdersRepository(SmartTeapotsDbContext dbContext, Cart cart)
        {
            _dbContext = dbContext;
            _cart = cart;
        }

        public void CreateAnOrder(string username)
        {
            OrderProduct orderProduct;
            Order order = new Order();
            User user = _dbContext.MyUsers.FirstOrDefault(u => u.Login == username)!;
            
            if (user != null)
            {
                order = new Order { OrderStatusId = 1, User = user, OrderDate = DateTime.Now };
                _dbContext.Orders.Add(order);

                for (int i = 0; i < _cart.CartItems.Count; i++)
                {
                    orderProduct = new OrderProduct { Order = order, SmartTeapot = _cart.CartItems[i].SmartTeapot, Quantity = _cart.CartItems[i].Quantity };
                    _dbContext.OrderProducts.Add(orderProduct);
                }

                _dbContext.SaveChanges();
            }
        }
    }
}
