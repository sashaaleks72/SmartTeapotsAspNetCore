using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartTeapotsWebProject.Data.Models;

namespace SmartTeapotsWebProject.Data.DBContexts
{
    public class SmartTeapotsDbContext : IdentityDbContext
    {
        public SmartTeapotsDbContext(DbContextOptions<SmartTeapotsDbContext> options) : base(options) { }

        public DbSet<SmartTeapot> SmartTeapots { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;
        public DbSet<User> MyUsers { get; set; } = null!;
        public DbSet<Role> MyRoles { get; set; } = null!;
        public DbSet<OrderProduct> OrderProducts { get; set; } = null!;
        public DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SmartTeapot>().HasData(
                new SmartTeapot()
                { Id = 1, Name = "SmartTeapot1", Color = "Black", Material = "Plastic", Capacity = 2.3, Power = 1200, Price = 2399, Quantity = 12, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_1.png",
                    Warranty = 12 },
                new SmartTeapot() 
                { Id = 2, Name = "SmartTeapot2", Color = "Brown", Material = "Metal", Capacity = 1.4, Power = 1400, Price = 1289, Quantity = 23, Producer = "Tefal",
                    ProducingCountry = "Germany",
                    ProductImg = "/img/catalog/catalog_2.png",
                    Warranty = 24
                },
                new SmartTeapot()
                { Id = 3, Name = "SmartTeapot3", Color = "White", Material = "Plastic", Capacity = 1.7, Power = 1500, Price = 3259, Quantity = 4, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_3.png",
                    Warranty = 18
                },
                new SmartTeapot()
                { Id = 4, Name = "SmartTeapot4", Color = "White", Material = "Plastic", Capacity = 1.7, Power = 1500, Price = 3259, Quantity = 4, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_4.png",
                    Warranty = 18
                },
                new SmartTeapot()
                { Id = 5, Name = "SmartTeapot5", Color = "White", Material = "Plastic", Capacity = 1.7, Power = 1500, Price = 3259, Quantity = 4, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_5.png",
                    Warranty = 18
                },
                new SmartTeapot()
                { Id = 6, Name = "SmartTeapot6", Color = "White", Material = "Plastic", Capacity = 1.7, Power = 1500, Price = 3259, Quantity = 4, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_6.png",
                    Warranty = 18
                },
                new SmartTeapot()
                { Id = 7, Name = "SmartTeapot7", Color = "White", Material = "Plastic", Capacity = 1.7, Power = 1500, Price = 3259, Quantity = 4, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_7.png",
                    Warranty = 18
                },
                new SmartTeapot()
                { Id = 8, Name = "SmartTeapot8", Color = "White", Material = "Plastic", Capacity = 1.7, Power = 1500, Price = 3259, Quantity = 4, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_8.png",
                    Warranty = 18
                },
                new SmartTeapot()
                { Id = 9, Name = "SmartTeapot9", Color = "White", Material = "Plastic", Capacity = 1.7, Power = 1500, Price = 3259, Quantity = 4, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_9.png",
                    Warranty = 18
                },
                new SmartTeapot()
                { Id = 10, Name = "SmartTeapot10", Color = "White", Material = "Plastic", Capacity = 1.7, Power = 1500, Price = 3259, Quantity = 4, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_10.png",
                    Warranty = 18
                },
                new SmartTeapot()
                { Id = 11, Name = "SmartTeapot11", Color = "White", Material = "Plastic", Capacity = 1.7, Power = 1500, Price = 3259, Quantity = 4, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_11.png",
                    Warranty = 18
                },
                new SmartTeapot()
                { Id = 12, Name = "SmartTeapot12", Color = "White", Material = "Plastic", Capacity = 1.7, Power = 1500, Price = 3259, Quantity = 4, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_12.png",
                    Warranty = 18
                },
                new SmartTeapot()
                { Id = 13, Name = "SmartTeapot13", Color = "White", Material = "Plastic", Capacity = 1.7, Power = 1500, Price = 3259, Quantity = 4, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_13.png",
                    Warranty = 18
                },
                new SmartTeapot()
                { Id = 14, Name = "SmartTeapot14", Color = "White", Material = "Plastic", Capacity = 1.7, Power = 1500, Price = 3259, Quantity = 4, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_14.png",
                    Warranty = 18
                },
                new SmartTeapot()
                { Id = 15, Name = "SmartTeapot15", Color = "White", Material = "Plastic", Capacity = 1.7, Power = 1500, Price = 3259, Quantity = 4, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_15.png",
                    Warranty = 18
                },
                new SmartTeapot()
                { Id = 16, Name = "SmartTeapot16", Color = "White", Material = "Plastic", Capacity = 1.7, Power = 1500, Price = 3259, Quantity = 4, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_16.png",
                    Warranty = 18
                },
                new SmartTeapot()
                { Id = 17, Name = "SmartTeapot17", Color = "White", Material = "Plastic", Capacity = 1.7, Power = 1500, Price = 3259, Quantity = 4, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_17.png",
                    Warranty = 18
                },
                new SmartTeapot()
                { Id = 18, Name = "SmartTeapot18", Color = "White", Material = "Plastic", Capacity = 1.7, Power = 1500, Price = 3259, Quantity = 4, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_18.png",
                    Warranty = 18
                },
                new SmartTeapot()
                { Id = 19, Name = "SmartTeapot19", Color = "White", Material = "Plastic", Capacity = 1.7, Power = 1500, Price = 3259, Quantity = 4, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_19.png",
                    Warranty = 18
                },
                new SmartTeapot()
                { Id = 20, Name = "SmartTeapot20", Color = "White", Material = "Plastic", Capacity = 1.7, Power = 1500, Price = 3259, Quantity = 4, Producer = "Xiaomi",
                    ProducingCountry = "China",
                    ProductImg = "/img/catalog/catalog_20.png",
                    Warranty = 18
                });
        }
    }
}
