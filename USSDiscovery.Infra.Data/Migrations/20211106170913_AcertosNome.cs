using Microsoft.EntityFrameworkCore.Migrations;

namespace USSDiscovery.Infra.Data.Migrations
{
    public partial class AcertosNome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimensao",
                table: "Planetas");

            migrationBuilder.AddColumn<decimal>(
                name: "Tamanho",
                table: "Planetas",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tamanho",
                table: "Planetas");

            migrationBuilder.AddColumn<decimal>(
                name: "Dimensao",
                table: "Planetas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
