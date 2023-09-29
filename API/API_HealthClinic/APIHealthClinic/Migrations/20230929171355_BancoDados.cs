using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIHealthClinic.Migrations
{
    /// <inheritdoc />
    public partial class BancoDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorarioAbertura",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "HorarioFechamento",
                table: "Consulta");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HorarioAbertura",
                table: "Clinica",
                type: "TIME",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HorarioFechamento",
                table: "Clinica",
                type: "TIME",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorarioAbertura",
                table: "Clinica");

            migrationBuilder.DropColumn(
                name: "HorarioFechamento",
                table: "Clinica");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HorarioAbertura",
                table: "Consulta",
                type: "TIME",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HorarioFechamento",
                table: "Consulta",
                type: "TIME",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
