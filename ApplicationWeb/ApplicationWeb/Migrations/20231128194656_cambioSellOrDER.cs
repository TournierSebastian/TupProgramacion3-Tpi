using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationWeb.Migrations
{
    /// <inheritdoc />
    public partial class cambioSellOrDER : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "DtoSellOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DtoSellOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DtoSellOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "DtoSellOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityProducts",
                table: "DtoSellOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "DtoSellOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation",
                table: "DtoSellOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "DtoSellOrders");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "DtoSellOrders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DtoSellOrders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "DtoSellOrders");

            migrationBuilder.DropColumn(
                name: "QuantityProducts",
                table: "DtoSellOrders");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "DtoSellOrders");

            migrationBuilder.DropColumn(
                name: "Validation",
                table: "DtoSellOrders");
        }
    }
}
