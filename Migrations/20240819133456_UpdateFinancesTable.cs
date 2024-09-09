using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFinancesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cariid",
                table: "Finances",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Finances_Cariid",
                table: "Finances",
                column: "Cariid");

            migrationBuilder.AddForeignKey(
                name: "FK_Finances_Caris_Cariid",
                table: "Finances",
                column: "Cariid",
                principalTable: "Caris",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Finances_Caris_Cariid",
                table: "Finances");

            migrationBuilder.DropIndex(
                name: "IX_Finances_Cariid",
                table: "Finances");

            migrationBuilder.DropColumn(
                name: "Cariid",
                table: "Finances");
        }
    }
}
