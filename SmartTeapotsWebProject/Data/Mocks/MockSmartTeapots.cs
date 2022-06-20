using SmartTeapotsWebProject.Data.Interfaces;
using SmartTeapotsWebProject.Data.Models;

namespace SmartTeapotsWebProject.Data.Mocks
{
    public class MockSmartTeapots : IAllSmartTeapots
    {
        public IEnumerable<SmartTeapot> SmartTeapots
        {
            get
            {
                SmartTeapot t1 = new() {
                    Id = 1,
                    Name = "SmartTeapot1",
                    Color = "Black",
                    Material = "Plastic",
                    Capacity = 2.3,
                    Power = 1200,
                    Price = 2399,
                    Quantity = 12,
                    Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_1.png",
                    Warranty = 12
                };

                SmartTeapot t2 = new()
                {
                    Id = 2,
                    Name = "SmartTeapot2",
                    Color = "Brown",
                    Material = "Metal",
                    Capacity = 1.4,
                    Power = 1400,
                    Price = 1289,
                    Quantity = 23,
                    Producer = "Tefal",
                    ProducingCountry = "Germany",
                    ProductImg = "/img/catalog/catalog_2.png",
                    Warranty = 24
                };

                SmartTeapot t3 = new()
                {
                    Id = 3,
                    Name = "SmartTeapot3",
                    Color = "White",
                    Material = "Plastic",
                    Capacity = 1.7,
                    Power = 1500,
                    Price = 3259,
                    Quantity = 4,
                    Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_3.png",
                    Warranty = 18
                };

                return new List<SmartTeapot> { t1, t2, t3};
            }
        }

        public SmartTeapot GetSmartTeapotById(int carId) => throw new NotImplementedException();
    }
}
