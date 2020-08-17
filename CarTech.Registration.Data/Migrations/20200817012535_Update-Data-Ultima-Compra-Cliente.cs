using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarTech.Registration.Data.Migrations
{
    public partial class UpdateDataUltimaCompraCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataUltimaCompra",
                table: "Clientes",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataUltimaCompra",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
