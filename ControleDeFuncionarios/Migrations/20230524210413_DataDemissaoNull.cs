using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeFuncionarios.Migrations
{
    public partial class DataDemissaoNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CNPJ",
                table: "Empresa",
                newName: "Cnpj");

            migrationBuilder.RenameColumn(
                name: "CBO",
                table: "Cargo",
                newName: "Cbo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDemissao",
                table: "Colaborador",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cnpj",
                table: "Empresa",
                newName: "CNPJ");

            migrationBuilder.RenameColumn(
                name: "Cbo",
                table: "Cargo",
                newName: "CBO");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDemissao",
                table: "Colaborador",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
