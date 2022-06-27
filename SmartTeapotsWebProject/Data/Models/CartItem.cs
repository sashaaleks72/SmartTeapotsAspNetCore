using System.ComponentModel.DataAnnotations;

namespace SmartTeapotsWebProject.Data.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public string CartId { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public double TotalSum
        {
            get
            {
                return Quantity * Price;
            }
        }

        public virtual SmartTeapot SmartTeapot { get; set; }

    }
}
