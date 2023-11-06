using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationWeb.Migrations
{
    /// <inheritdoc />
    public partial class EditSellOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DtoSellOrders_Products_ProductidProducts",
                table: "DtoSellOrders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_DtoSellOrders_ProductidProducts",
                table: "DtoSellOrders");

            migrationBuilder.RenameColumn(
                name: "ProductidProducts",
                table: "DtoSellOrders",
                newName: "TotalValue");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalValue",
                table: "DtoSellOrders",
                newName: "ProductidProducts");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    idProducts = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.idProducts);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DtoSellOrders_ProductidProducts",
                table: "DtoSellOrders",
                column: "ProductidProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_DtoSellOrders_Products_ProductidProducts",
                table: "DtoSellOrders",
                column: "ProductidProducts",
                principalTable: "Products",
                principalColumn: "idProducts",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
