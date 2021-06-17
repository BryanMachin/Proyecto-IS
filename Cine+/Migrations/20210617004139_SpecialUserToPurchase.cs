using Microsoft.EntityFrameworkCore.Migrations;

namespace Cine_.Migrations
{
    public partial class SpecialUserToPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpecialUserSelected",
                table: "Purchases",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialUserSelected",
                table: "Purchases");
        }
    }
}
