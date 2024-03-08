using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practica_14_02_2024.Migrations
{
    public partial class Regadamia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ordenescompra_compradores_compradorId",
                table: "ordenescompra");

            migrationBuilder.DropIndex(
                name: "IX_ordenescompra_compradorId",
                table: "ordenescompra");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "ordenescompra");

            migrationBuilder.DropColumn(
                name: "CondicionPago",
                table: "ordenescompra");

            migrationBuilder.DropColumn(
                name: "Consecutivo",
                table: "ordenescompra");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "ordenescompra");

            migrationBuilder.DropColumn(
                name: "Empresa",
                table: "ordenescompra");

            migrationBuilder.DropColumn(
                name: "Entrega",
                table: "ordenescompra");

            migrationBuilder.DropColumn(
                name: "Iva",
                table: "ordenescompra");

            migrationBuilder.DropColumn(
                name: "Moneda",
                table: "ordenescompra");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "ordenescompra");

            migrationBuilder.DropColumn(
                name: "TiempoEntrega",
                table: "ordenescompra");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "ordenescompra");

            migrationBuilder.DropColumn(
                name: "Vendedor",
                table: "ordenescompra");

            migrationBuilder.DropColumn(
                name: "compradorId",
                table: "ordenescompra");

            migrationBuilder.AddColumn<int>(
                name: "ordencompraId",
                table: "compradores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_compradores_ordencompraId",
                table: "compradores",
                column: "ordencompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_compradores_ordenescompra_ordencompraId",
                table: "compradores",
                column: "ordencompraId",
                principalTable: "ordenescompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_compradores_ordenescompra_ordencompraId",
                table: "compradores");

            migrationBuilder.DropIndex(
                name: "IX_compradores_ordencompraId",
                table: "compradores");

            migrationBuilder.DropColumn(
                name: "ordencompraId",
                table: "compradores");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "ordenescompra",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CondicionPago",
                table: "ordenescompra",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Consecutivo",
                table: "ordenescompra",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "ordenescompra",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Empresa",
                table: "ordenescompra",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Entrega",
                table: "ordenescompra",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Iva",
                table: "ordenescompra",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Moneda",
                table: "ordenescompra",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Subtotal",
                table: "ordenescompra",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "TiempoEntrega",
                table: "ordenescompra",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Total",
                table: "ordenescompra",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Vendedor",
                table: "ordenescompra",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "compradorId",
                table: "ordenescompra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ordenescompra_compradorId",
                table: "ordenescompra",
                column: "compradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ordenescompra_compradores_compradorId",
                table: "ordenescompra",
                column: "compradorId",
                principalTable: "compradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
