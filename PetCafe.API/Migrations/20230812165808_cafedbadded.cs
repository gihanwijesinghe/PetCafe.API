using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCafe.API.Migrations
{
    public partial class cafedbadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CafeId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Cafes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CafeId",
                table: "Employees",
                column: "CafeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Cafes_CafeId",
                table: "Employees",
                column: "CafeId",
                principalTable: "Cafes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Cafes_CafeId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Cafes");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CafeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CafeId",
                table: "Employees");
        }
    }
}
