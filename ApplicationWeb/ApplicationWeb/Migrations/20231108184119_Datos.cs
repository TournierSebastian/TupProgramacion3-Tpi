using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApplicationWeb.Migrations
{
    /// <inheritdoc />
    public partial class Datos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DtoUsers",
                columns: new[] { "idUser", "Email", "Password", "UserName", "UserType" },
                values: new object[,]
                {
                    { 1, "SuperAdmin@SuperAdmin.com", "f94d3a61fc4b322de134ab222d849e50f4a407f68d201ddd1ff44e57ee20339d", "SuperAdmin", "SuperAdmin" },
                    { 2, "Admin@Admin.com", "c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f", "Admin", "Admin" },
                    { 3, "Customer@Customer.com", "bf3763383aaf43069885db20b386631c6d5d8b8481df2a26769e9de5fe2f9c82", "Customer", "Customer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DtoUsers",
                keyColumn: "idUser",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DtoUsers",
                keyColumn: "idUser",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DtoUsers",
                keyColumn: "idUser",
                keyValue: 3);
        }
    }
}
