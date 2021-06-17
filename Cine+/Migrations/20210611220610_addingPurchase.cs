using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cine_.Migrations
{
    public partial class addingPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "Clients",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    ClientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tickets = table.Column<int>(type: "int", nullable: false),
                    PurchaseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => new { x.ClientID, x.MovieID, x.RoomID, x.ShiftID, x.Date, x.PurchaseDate });
                    table.ForeignKey(
                        name: "FK_Purchase_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_Presentations_MovieID_RoomID_ShiftID_Date",
                        columns: x => new { x.MovieID, x.RoomID, x.ShiftID, x.Date },
                        principalTable: "Presentations",
                        principalColumns: new[] { "MovieID", "RoomID", "ShiftID", "Date" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_MovieID_RoomID_ShiftID_Date",
                table: "Purchase",
                columns: new[] { "MovieID", "RoomID", "ShiftID", "Date" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "Clients",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);
        }
    }
}
