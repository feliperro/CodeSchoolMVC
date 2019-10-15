using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurantes.Infrastructure.Migrations
{
    public partial class ordenhasproduct3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrdenTieneProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrdenTieneProducto",
                nullable: false,
                defaultValue: 0);
        }
    }
}
