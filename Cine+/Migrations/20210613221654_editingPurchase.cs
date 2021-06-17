using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cine_.Migrations
{
    public partial class editingPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Clients_ClientID",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Presentations_MovieID_RoomID_ShiftID_Date",
                table: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "Purchase");

            migrationBuilder.RenameTable(
                name: "Purchase",
                newName: "Purchases");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_MovieID_RoomID_ShiftID_Date",
                table: "Purchases",
                newName: "IX_Purchases_MovieID_RoomID_ShiftID_Date");

            migrationBuilder.AlterColumn<string>(
                name: "PurchaseID",
                table: "Purchases",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "CreditCardID",
                table: "Purchases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MembershipID",
                table: "Purchases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                columns: new[] { "ClientID", "MovieID", "RoomID", "ShiftID", "Date" });

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Clients_ClientID",
                table: "Purchases",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Presentations_MovieID_RoomID_ShiftID_Date",
                table: "Purchases",
                columns: new[] { "MovieID", "RoomID", "ShiftID", "Date" },
                principalTable: "Presentations",
                principalColumns: new[] { "MovieID", "RoomID", "ShiftID", "Date" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Clients_ClientID",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Presentations_MovieID_RoomID_ShiftID_Date",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "CreditCardID",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "MembershipID",
                table: "Purchases");

            migrationBuilder.RenameTable(
                name: "Purchases",
                newName: "Purchase");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_MovieID_RoomID_ShiftID_Date",
                table: "Purchase",
                newName: "IX_Purchase_MovieID_RoomID_ShiftID_Date");

            migrationBuilder.AlterColumn<Guid>(
                name: "PurchaseID",
                table: "Purchase",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "Purchase",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase",
                columns: new[] { "ClientID", "MovieID", "RoomID", "ShiftID", "Date", "PurchaseDate" });

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Clients_ClientID",
                table: "Purchase",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Presentations_MovieID_RoomID_ShiftID_Date",
                table: "Purchase",
                columns: new[] { "MovieID", "RoomID", "ShiftID", "Date" },
                principalTable: "Presentations",
                principalColumns: new[] { "MovieID", "RoomID", "ShiftID", "Date" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
