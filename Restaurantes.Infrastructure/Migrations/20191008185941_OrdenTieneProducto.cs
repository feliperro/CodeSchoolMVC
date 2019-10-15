using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurantes.Infrastructure.Migrations
{
    public partial class OrdenTieneProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrdenTieneProducto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Subtotal",
                table: "OrdenTieneProducto",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrdenTieneProducto");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "OrdenTieneProducto");
        }
    }
}
