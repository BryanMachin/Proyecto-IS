using Microsoft.EntityFrameworkCore.Migrations;

namespace Cine_.Migrations
{
    public partial class editingPurchaseAddingProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "MoneyImport",
                table: "Purchases",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "PointsImport",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoneyImport",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PointsImport",
                table: "Purchases");
        }
    }
}
