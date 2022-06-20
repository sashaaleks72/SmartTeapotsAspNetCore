using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartTeapotsWebProject.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SmartTeapots",
                columns: new[] { "Id", "Capacity", "Color", "Material", "Name", "Power", "Price", "Producer", "ProducingCountry", "ProductImg", "Quantity", "Warranty" },
                values: new object[,]
                {
                    { 1, 2.2999999999999998, "Black", "Plastic", "SmartTeapot1", 1200, 2399.0, "Xiaomi", "China", "/img/catalog/catalog_1.png", 12, 12 },
                    { 2, 1.3999999999999999, "Brown", "Metal", "SmartTeapot2", 1400, 1289.0, "Tefal", "Germany", "/img/catalog/catalog_2.png", 23, 24 },
                    { 3, 1.7, "White", "Plastic", "SmartTeapot3", 1500, 3259.0, "Xiaomi", "China", "/img/catalog/catalog_3.png", 4, 18 },
                    { 4, 1.7, "White", "Plastic", "SmartTeapot4", 1500, 3259.0, "Xiaomi", "China", "/img/catalog/catalog_4.png", 4, 18 },
                    { 5, 1.7, "White", "Plastic", "SmartTeapot5", 1500, 3259.0, "Xiaomi", "China", "/img/catalog/catalog_5.png", 4, 18 },
                    { 6, 1.7, "White", "Plastic", "SmartTeapot6", 1500, 3259.0, "Xiaomi", "China", "/img/catalog/catalog_6.png", 4, 18 },
                    { 7, 1.7, "White", "Plastic", "SmartTeapot7", 1500, 3259.0, "Xiaomi", "China", "/img/catalog/catalog_7.png", 4, 18 },
                    { 8, 1.7, "White", "Plastic", "SmartTeapot8", 1500, 3259.0, "Xiaomi", "China", "/img/catalog/catalog_8.png", 4, 18 },
                    { 9, 1.7, "White", "Plastic", "SmartTeapot9", 1500, 3259.0, "Xiaomi", "China", "/img/catalog/catalog_9.png", 4, 18 },
                    { 10, 1.7, "White", "Plastic", "SmartTeapot10", 1500, 3259.0, "Xiaomi", "China", "/img/catalog/catalog_10.png", 4, 18 },
                    { 11, 1.7, "White", "Plastic", "SmartTeapot11", 1500, 3259.0, "Xiaomi", "China", "/img/catalog/catalog_11.png", 4, 18 },
                    { 12, 1.7, "White", "Plastic", "SmartTeapot12", 1500, 3259.0, "Xiaomi", "China", "/img/catalog/catalog_12.png", 4, 18 },
                    { 13, 1.7, "White", "Plastic", "SmartTeapot13", 1500, 3259.0, "Xiaomi", "China", "/img/catalog/catalog_13.png", 4, 18 },
                    { 14, 1.7, "White", "Plastic", "SmartTeapot14", 1500, 3259.0, "Xiaomi", "China", "/img/catalog/catalog_14.png", 4, 18 },
                    { 15, 1.7, "White", "Plastic", "SmartTeapot15", 1500, 3259.0, "Xiaomi", "China", "/img/catalog/catalog_15.png", 4, 18 },
                    { 16, 1.7, "White", "Plastic", "SmartTeapot16", 1500, 3259.0, "Xiaomi", "China", "/img/catalog/catalog_16.png", 4, 18 },
                    { 17, 1.7, "White", "Plastic", "SmartTeapot17", 1500, 3259.0, "Xiaomi", "China", "/img/catalog/catalog_17.png", 4, 18 },
                    { 18, 1.7, "White", "Plastic", "SmartTeapot18", 1500, 3259.0, "Xiaomi", "China", "/img/catalog/catalog_18.png", 4, 18 },
                    { 19, 1.7, "White", "Plastic", "SmartTeapot19", 1500, 3259.0, "Xiaomi", "China", "/img/catalog/catalog_19.png", 4, 18 },
                    { 20, 1.7, "White", "Plastic", "SmartTeapot20", 1500, 3259.0, "Xiaomi", "China", "/img/catalog/catalog_20.png", 4, 18 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SmartTeapots",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
