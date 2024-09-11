using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkLearnProject4.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temp = table.Column<double>(type: "float", nullable: false),
                    MinTemp = table.Column<double>(type: "float", nullable: false),
                    MaxTemp = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("31bda01e-5285-4e5e-ac50-ebfb46a67331"), new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "petr@example.com", "Petr" },
                    { new Guid("45040642-bdd4-4fc3-9ebe-3e5b33844a5d"), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "nick@example.com", "Nick" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Weathers");
        }
    }
}
