namespace SmartTeapotsWebProject.Data.Models
{
    public class Order
    {
        public int Id { set; get; }
        public DateTime OrderDate { set; get; }

        public int UserId { set; get; }
        public virtual User User { set; get; }

        public int OrderStatusId { set; get; }
        public virtual OrderStatus OrderStatus { set; get; }

        public virtual List<OrderProduct> OrderProducts { set; get; } = new();
    }
}