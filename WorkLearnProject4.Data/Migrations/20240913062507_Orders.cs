using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkLearnProject4.Data.Migrations
{
    /// <inheritdoc />
    public partial class Orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("4fb3261f-3695-4261-88e3-b9a93a9573c1"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f30f0d9a-757b-41f2-8cf1-0ab32ef09388"));

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
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
                    { new Guid("42badd52-5988-47fc-a099-ec374923bd7f"), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "nick@example.com", "Nick" },
                    { new Guid("95766c2e-25e8-4f61-a7bd-44c3ce457257"), new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "petr@example.com", "Petr" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("42badd52-5988-47fc-a099-ec374923bd7f"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("95766c2e-25e8-4f61-a7bd-44c3ce457257"));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("4fb3261f-3695-4261-88e3-b9a93a9573c1"), new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "petr@example.com", "Petr" },
                    { new Guid("f30f0d9a-757b-41f2-8cf1-0ab32ef09388"), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "nick@example.com", "Nick" }
                });
        }
    }
}
