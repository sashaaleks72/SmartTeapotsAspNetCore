namespace SmartTeapotsWebProject.Data.Models
{
    public class SmartTeapot
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public int Quantity { set; get; }

        public string Color { set; get; }

        public string Material { set; get; }

        public double Price { set; get; }

        public string Producer { set; get; }

        public int Warranty { set; get; }

        public int Power { set; get; }

        public double Capacity { set; get; }

        public string ProducingCountry { set; get; }

        public string? ProductImg { set; get; }
    }
}
