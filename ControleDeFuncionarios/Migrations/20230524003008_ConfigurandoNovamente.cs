using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeFuncionarios.Migrations
{
    public partial class ConfigurandoNovamente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_CargoModel_CargoId",
                table: "Colaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_EmpresaModel_EmpresaId",
                table: "Colaborador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpresaModel",
                table: "EmpresaModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CargoModel",
                table: "CargoModel");

            migrationBuilder.RenameTable(
                name: "EmpresaModel",
                newName: "Empresa");

            migrationBuilder.RenameTable(
                name: "CargoModel",
                newName: "Cargo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empresa",
                table: "Empresa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cargo",
                table: "Cargo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Cargo_CargoId",
                table: "Colaborador",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Empresa_EmpresaId",
                table: "Colaborador",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Cargo_CargoId",
                table: "Colaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Empresa_EmpresaId",
                table: "Colaborador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empresa",
                table: "Empresa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cargo",
                table: "Cargo");

            migrationBuilder.RenameTable(
                name: "Empresa",
                newName: "EmpresaModel");

            migrationBuilder.RenameTable(
                name: "Cargo",
                newName: "CargoModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpresaModel",
                table: "EmpresaModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CargoModel",
                table: "CargoModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_CargoModel_CargoId",
                table: "Colaborador",
                column: "CargoId",
                principalTable: "CargoModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_EmpresaModel_EmpresaId",
                table: "Colaborador",
                column: "EmpresaId",
                principalTable: "EmpresaModel",
                principalColumn: "Id");
        }
    }
}
