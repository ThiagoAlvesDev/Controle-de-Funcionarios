using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeFuncionarios.Migrations
{
    public partial class InsertDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAdmissao",
                table: "Colaborador",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDemissao",
                table: "Colaborador",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAdmissao",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "DataDemissao",
                table: "Colaborador");
        }
    }
}
