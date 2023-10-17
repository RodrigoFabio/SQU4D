using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQU4D.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoNovasClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VeiculoId",
                table: "Alerts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VeiculoId1",
                table: "Alerts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Encaminhamento",
                columns: table => new
                {
                    IdEncaminhamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlertId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    EncaminhamentoAtivo = table.Column<bool>(type: "bit", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioInc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioAlt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrigemRetorno = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encaminhamento", x => x.IdEncaminhamento);
                    table.ForeignKey(
                        name: "FK_Encaminhamento_Alerts_AlertId",
                        column: x => x.AlertId,
                        principalTable: "Alerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Encaminhamento_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veiculoes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Chassi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculoes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_VeiculoId1",
                table: "Alerts",
                column: "VeiculoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Encaminhamento_AlertId",
                table: "Encaminhamento",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_Encaminhamento_UsuarioId",
                table: "Encaminhamento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculoes_ClienteId",
                table: "Veiculoes",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Veiculoes_VeiculoId1",
                table: "Alerts",
                column: "VeiculoId1",
                principalTable: "Veiculoes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Veiculoes_VeiculoId1",
                table: "Alerts");

            migrationBuilder.DropTable(
                name: "Encaminhamento");

            migrationBuilder.DropTable(
                name: "Veiculoes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_VeiculoId1",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "VeiculoId",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "VeiculoId1",
                table: "Alerts");
        }
    }
}
