using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationWeb.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idProduct",
                table: "DtoSellOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idUser",
                table: "DtoSellOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idProduct",
                table: "DtoSellOrders");

            migrationBuilder.DropColumn(
                name: "idUser",
                table: "DtoSellOrders");
        }
    }
}
