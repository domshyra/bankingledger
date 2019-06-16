using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingLedger.Migrations
{
    public partial class depositBal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Account",
                newName: "Ballance");

            migrationBuilder.AddColumn<decimal>(
                name: "Ballance",
                table: "Deposit",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ballance",
                table: "Deposit");

            migrationBuilder.RenameColumn(
                name: "Ballance",
                table: "Account",
                newName: "Balance");
        }
    }
}
