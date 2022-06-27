namespace SmartTeapotsWebProject.Data.Models
{
    public class OrderProduct
    {
        public int Id { set; get; }
        
        public int Quantity { set; get; }

        public int OrderId { set; get; }
        public virtual Order Order { set; get; }

        public int SmartTeapotId { set; get; }
        public virtual SmartTeapot SmartTeapot { set; get; }
    }
}