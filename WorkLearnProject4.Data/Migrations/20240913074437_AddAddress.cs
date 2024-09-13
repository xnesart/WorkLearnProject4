using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkLearnProject4.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("575d70c9-6689-41bd-b9f5-8914c92d0f83"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("b14328b9-18e8-40c9-9773-fdb555ccaea9"));

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("7a580e44-924d-4e08-9994-28b5b2a7faa5"), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "nick@example.com", "Nick" },
                    { new Guid("d687b2ba-d937-4db0-8804-5fad81b6f843"), new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "petr@example.com", "Petr" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("7a580e44-924d-4e08-9994-28b5b2a7faa5"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("d687b2ba-d937-4db0-8804-5fad81b6f843"));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("575d70c9-6689-41bd-b9f5-8914c92d0f83"), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "nick@example.com", "Nick" },
                    { new Guid("b14328b9-18e8-40c9-9773-fdb555ccaea9"), new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "petr@example.com", "Petr" }
                });
        }
    }
}
