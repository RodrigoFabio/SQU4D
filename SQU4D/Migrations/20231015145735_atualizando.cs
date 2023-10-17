using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQU4D.Migrations
{
    /// <inheritdoc />
    public partial class atualizando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlertApiId = table.Column<int>(type: "int", nullable: false),
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
                    DefinitionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
