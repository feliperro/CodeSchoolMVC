using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurantes.Infrastructure.Migrations
{
    public partial class productRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenTieneProducto_Ordenes_OrdenId",
                table: "OrdenTieneProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenTieneProducto_Productos_ProductoId",
                table: "OrdenTieneProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenTieneProducto_Ordenes_OrdenId",
                table: "OrdenTieneProducto",
                column: "OrdenId",
                principalTable: "Ordenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenTieneProducto_Productos_ProductoId",
                table: "OrdenTieneProducto",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenTieneProducto_Ordenes_OrdenId",
                table: "OrdenTieneProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenTieneProducto_Productos_ProductoId",
                table: "OrdenTieneProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenTieneProducto_Ordenes_OrdenId",
                table: "OrdenTieneProducto",
                column: "OrdenId",
                principalTable: "Ordenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenTieneProducto_Productos_ProductoId",
                table: "OrdenTieneProducto",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
