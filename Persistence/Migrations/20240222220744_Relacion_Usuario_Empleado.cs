using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Relacion_Usuario_Empleado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Edad",
                table: "Usuario",
                newName: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdEmpleado",
                table: "Usuario",
                column: "IdEmpleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Empleado_IdEmpleado",
                table: "Usuario",
                column: "Empleado",
                principalTable: "Empleado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Empleado_IdEmpleado",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdEmpleado",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "IdEmpleado",
                table: "Usuario",
                newName: "Edad");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Usuario",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Usuario",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Usuario",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Usuario",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
