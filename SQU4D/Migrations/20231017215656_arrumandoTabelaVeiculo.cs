using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQU4D.Migrations
{
    /// <inheritdoc />
    public partial class arrumandoTabelaVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Veiculoes_VeiculoId1",
                table: "Alerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculoes_Clientes_ClienteId",
                table: "Veiculoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculoes",
                table: "Veiculoes");

            migrationBuilder.RenameTable(
                name: "Veiculoes",
                newName: "Veiculos");

            migrationBuilder.RenameIndex(
                name: "IX_Veiculoes_ClienteId",
                table: "Veiculos",
                newName: "IX_Veiculos_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Veiculos_VeiculoId1",
                table: "Alerts",
                column: "VeiculoId1",
                principalTable: "Veiculos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Clientes_ClienteId",
                table: "Veiculos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Veiculos_VeiculoId1",
                table: "Alerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Clientes_ClienteId",
                table: "Veiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos");

            migrationBuilder.RenameTable(
                name: "Veiculos",
                newName: "Veiculoes");

            migrationBuilder.RenameIndex(
                name: "IX_Veiculos_ClienteId",
                table: "Veiculoes",
                newName: "IX_Veiculoes_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculoes",
                table: "Veiculoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Veiculoes_VeiculoId1",
                table: "Alerts",
                column: "VeiculoId1",
                principalTable: "Veiculoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculoes_Clientes_ClienteId",
                table: "Veiculoes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
