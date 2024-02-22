using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RelacionTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTipoProducto",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "Empleado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdTipoProducto",
                table: "Producto",
                column: "IdTipoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdEmpresa",
                table: "Empleado",
                column: "IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Empresa_IdEmpresa",
                table: "Empleado",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_TipoProducto_IdTipoProducto",
                table: "Producto",
                column: "IdTipoProducto",
                principalTable: "TipoProducto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Empresa_IdEmpresa",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_TipoProducto_IdTipoProducto",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_IdTipoProducto",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_IdEmpresa",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "IdTipoProducto",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "Empleado");
        }
    }
}
