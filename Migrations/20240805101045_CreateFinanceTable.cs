using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateFinanceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caris",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tel_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ulke = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    il = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ilce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mahalle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sokak = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bina_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    daire_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    banka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    iban = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alacak = table.Column<decimal>(type: "decimal(18,8)", nullable: true),
                    borc = table.Column<decimal>(type: "decimal(18,8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caris", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Finances",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cari_id = table.Column<int>(type: "int", nullable: true),
                    odeme_tipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    miktar = table.Column<decimal>(type: "decimal(18,8)", nullable: true),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tarih = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finances", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caris");

            migrationBuilder.DropTable(
                name: "Finances");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
