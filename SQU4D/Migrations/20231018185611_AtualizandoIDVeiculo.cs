using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQU4D.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoIDVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlertApiId",
                table: "Alerts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlertApiId",
                table: "Alerts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
