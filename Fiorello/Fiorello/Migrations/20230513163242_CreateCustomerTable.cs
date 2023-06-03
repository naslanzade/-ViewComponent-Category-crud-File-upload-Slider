using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello.Migrations
{
    public partial class CreateCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "CreatedDate", "FullName", "SoftDeleted" },
                values: new object[] { 1, 16, new DateTime(2023, 5, 13, 20, 32, 42, 260, DateTimeKind.Local).AddTicks(3296), "Rasul Hasanov", false });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "CreatedDate", "FullName", "SoftDeleted" },
                values: new object[] { 2, 25, new DateTime(2023, 5, 13, 20, 32, 42, 260, DateTimeKind.Local).AddTicks(3385), "Novrasta Aslanzade", false });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "CreatedDate", "FullName", "SoftDeleted" },
                values: new object[] { 3, 19, new DateTime(2023, 5, 13, 20, 32, 42, 260, DateTimeKind.Local).AddTicks(3395), "Musa Afandiyev", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
