using SmartTeapotsWebProject.Data.Models;

namespace SmartTeapotsWebProject.Data.Interfaces
{
    public interface IAllOrders
    {
        void CreateAnOrder(string username);

        // List<Order> GetAllOrders();
    }
}
