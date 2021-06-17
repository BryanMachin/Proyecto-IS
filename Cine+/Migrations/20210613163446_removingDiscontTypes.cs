using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cine_.Migrations
{
    public partial class removingDiscontTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscountTypes",
                columns: table => new
                {
                    DiscountTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountRate = table.Column<float>(type: "real", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountTypes", x => x.DiscountTypeID);
                });
        }
    }
}
