using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetApp.Data.Migrations
{
    public partial class AddBudgetToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Budget_BudgetYearMonth",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_Budget_BudgetYearMonth",
                table: "Income");

            migrationBuilder.RenameColumn(
                name: "BudgetYearMonth",
                table: "Income",
                newName: "BudgetId");

            migrationBuilder.RenameIndex(
                name: "IX_Income_BudgetYearMonth",
                table: "Income",
                newName: "IX_Income_BudgetId");

            migrationBuilder.RenameColumn(
                name: "BudgetYearMonth",
                table: "Expenses",
                newName: "BudgetId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_BudgetYearMonth",
                table: "Expenses",
                newName: "IX_Expenses_BudgetId");

            migrationBuilder.RenameColumn(
                name: "YearMonth",
                table: "Budget",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Budget_BudgetId",
                table: "Expenses",
                column: "BudgetId",
                principalTable: "Budget",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Income_Budget_BudgetId",
                table: "Income",
                column: "BudgetId",
                principalTable: "Budget",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Budget_BudgetId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_Budget_BudgetId",
                table: "Income");

            migrationBuilder.RenameColumn(
                name: "BudgetId",
                table: "Income",
                newName: "BudgetYearMonth");

            migrationBuilder.RenameIndex(
                name: "IX_Income_BudgetId",
                table: "Income",
                newName: "IX_Income_BudgetYearMonth");

            migrationBuilder.RenameColumn(
                name: "BudgetId",
                table: "Expenses",
                newName: "BudgetYearMonth");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_BudgetId",
                table: "Expenses",
                newName: "IX_Expenses_BudgetYearMonth");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Budget",
                newName: "YearMonth");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Budget_BudgetYearMonth",
                table: "Expenses",
                column: "BudgetYearMonth",
                principalTable: "Budget",
                principalColumn: "YearMonth",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Income_Budget_BudgetYearMonth",
                table: "Income",
                column: "BudgetYearMonth",
                principalTable: "Budget",
                principalColumn: "YearMonth",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
