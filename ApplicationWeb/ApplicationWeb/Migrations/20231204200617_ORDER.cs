using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationWeb.Migrations
{
    /// <inheritdoc />
    public partial class ORDER : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "SellOrders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SellOrders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "SellOrders");

            migrationBuilder.DropColumn(
                name: "QuantityProducts",
                table: "SellOrders");

            migrationBuilder.DropColumn(
                name: "idProduct",
                table: "SellOrders");

            migrationBuilder.AddColumn<int>(
                name: "QuantityProducts",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityProducts",
                table: "OrderDetails");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "SellOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SellOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "SellOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityProducts",
                table: "SellOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idProduct",
                table: "SellOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
