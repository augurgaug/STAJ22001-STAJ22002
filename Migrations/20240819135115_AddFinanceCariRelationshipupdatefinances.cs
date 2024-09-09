using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApi.Migrations
{
    /// <inheritdoc />
    public partial class AddFinanceCariRelationshipupdatefinances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Finances_cari_id",
                table: "Finances",
                column: "cari_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Finances_Caris_cari_id",
                table: "Finances",
                column: "cari_id",
                principalTable: "Caris",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Finances_Caris_cari_id",
                table: "Finances");

            migrationBuilder.DropIndex(
                name: "IX_Finances_cari_id",
                table: "Finances");

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
    }
}
