using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationWeb.Migrations
{
    /// <inheritdoc />
    public partial class editdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellOrderId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellOrderId",
                table: "OrderDetails");
        }
    }
}
