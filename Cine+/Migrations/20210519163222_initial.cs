using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cine_.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    Synopsis = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
