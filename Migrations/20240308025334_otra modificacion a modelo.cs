using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practica_14_02_2024.Migrations
{
    public partial class otramodificacionamodelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_compradores_ordenescompra_ordencompraId",
                table: "compradores");

            migrationBuilder.RenameColumn(
                name: "ordencompraId",
                table: "compradores",
                newName: "OrdenCompraId");

            migrationBuilder.RenameIndex(
                name: "IX_compradores_ordencompraId",
                table: "compradores",
                newName: "IX_compradores_OrdenCompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_compradores_ordenescompra_OrdenCompraId",
                table: "compradores",
                column: "OrdenCompraId",
                principalTable: "ordenescompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_compradores_ordenescompra_OrdenCompraId",
                table: "compradores");

            migrationBuilder.RenameColumn(
                name: "OrdenCompraId",
                table: "compradores",
                newName: "ordencompraId");

            migrationBuilder.RenameIndex(
                name: "IX_compradores_OrdenCompraId",
                table: "compradores",
                newName: "IX_compradores_ordencompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_compradores_ordenescompra_ordencompraId",
                table: "compradores",
                column: "ordencompraId",
                principalTable: "ordenescompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
