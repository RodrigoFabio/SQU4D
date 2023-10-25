using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQU4D.Migrations
{
    /// <inheritdoc />
    public partial class configurandobd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chassi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationValue = table.Column<double>(type: "float", nullable: false),
                    DurationUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occurrences = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineHoursType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineHoursValue = table.Column<double>(type: "float", nullable: false),
                    EngineHoursUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineLinearTime = table.Column<int>(type: "int", nullable: false),
                    Bus = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LocationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Lon = table.Column<double>(type: "float", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcknowledgementStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ignored = table.Column<bool>(type: "bit", nullable: false),
                    Invisible = table.Column<bool>(type: "bit", nullable: false),
                    LinkType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkRel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefinitionLinkType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefinitionLinkRel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefinitionLinkUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefinitionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefinitionSuspectParameterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefinitionFailureModeIndicator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefinitionBus = table.Column<int>(type: "int", nullable: false),
                    DefinitionSourceAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefinitionThreeLetterAcronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefinitionId = table.Column<int>(type: "int", nullable: false),
                    DefinitionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VeiculoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerts_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_VeiculoId",
                table: "Alerts",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Encaminhamento_AlertId",
                table: "Encaminhamento",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_Encaminhamento_UsuarioId",
                table: "Encaminhamento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_ClienteId",
                table: "Veiculos",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Encaminhamento");

            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
