using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DtoUsers",
                table: "DtoUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DtoSellOrders",
                table: "DtoSellOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DtoProducts",
                table: "DtoProducts");

            migrationBuilder.RenameTable(
                name: "DtoUsers",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "DtoSellOrders",
                newName: "SellOrders");

            migrationBuilder.RenameTable(
                name: "DtoProducts",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "idUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SellOrders",
                table: "SellOrders",
                column: "idOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "idProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SellOrders",
                table: "SellOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "DtoUsers");

            migrationBuilder.RenameTable(
                name: "SellOrders",
                newName: "DtoSellOrders");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "DtoProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DtoUsers",
                table: "DtoUsers",
                column: "idUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DtoSellOrders",
                table: "DtoSellOrders",
                column: "idOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DtoProducts",
                table: "DtoProducts",
                column: "idProducts");
        }
    }
}
