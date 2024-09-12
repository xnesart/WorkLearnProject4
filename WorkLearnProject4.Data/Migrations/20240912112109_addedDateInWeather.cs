using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkLearnProject4.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedDateInWeather : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("05d14b86-ac19-4ea9-8103-b7ef5074913f"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("a4b87eb1-ae4f-431a-93c1-88a719d35683"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Weathers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("4fb3261f-3695-4261-88e3-b9a93a9573c1"), new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "petr@example.com", "Petr" },
                    { new Guid("f30f0d9a-757b-41f2-8cf1-0ab32ef09388"), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "nick@example.com", "Nick" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("4fb3261f-3695-4261-88e3-b9a93a9573c1"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f30f0d9a-757b-41f2-8cf1-0ab32ef09388"));

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Weathers");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("05d14b86-ac19-4ea9-8103-b7ef5074913f"), new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "petr@example.com", "Petr" },
                    { new Guid("a4b87eb1-ae4f-431a-93c1-88a719d35683"), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "nick@example.com", "Nick" }
                });
        }
    }
}
