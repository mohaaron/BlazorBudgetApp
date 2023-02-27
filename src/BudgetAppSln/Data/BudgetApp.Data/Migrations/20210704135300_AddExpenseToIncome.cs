using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetApp.Data.Migrations
{
    public partial class AddExpenseToIncome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PayDate",
                table: "Income",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IncomeId",
                table: "Expenses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Debts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    DebtType = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_IncomeId",
                table: "Expenses",
                column: "IncomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Income_IncomeId",
                table: "Expenses",
                column: "IncomeId",
                principalTable: "Income",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Income_IncomeId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "Debts");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_IncomeId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "PayDate",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "IncomeId",
                table: "Expenses");
        }
    }
}
