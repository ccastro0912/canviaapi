using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Canvia.Infrastructure.Orm.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    PKID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DocIdentidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Apellidos = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Nombres = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Activo = table.Column<bool>(type: "bit", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CUSTOMER__18ASBMMDIK8C5F9S", x => x.PKID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    PKID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PRODUCT__18ASBMMDIK8C5F9S", x => x.PKID);
                });

            migrationBuilder.CreateTable(
                name: "Cp",
                columns: table => new
                {
                    PKID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumCp = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IDCustomer = table.Column<int>(type: "int", nullable: true),
                    Moneda = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CP__21APPSKLPK976P8P", x => x.PKID);
                    table.ForeignKey(
                        name: "FK__CUSTOMER_CP__88P7C438",
                        column: x => x.IDCustomer,
                        principalTable: "Customer",
                        principalColumn: "PKID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemCp",
                columns: table => new
                {
                    PKID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", unicode: false, maxLength: 20, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IDProducto = table.Column<int>(type: "int", nullable: true),
                    IDCp = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ITEMCP__21APPSKLPK976P8P", x => x.PKID);
                    table.ForeignKey(
                        name: "FK__CP_ITEMCP__88P7C438",
                        column: x => x.IDCp,
                        principalTable: "Cp",
                        principalColumn: "PKID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PRODUCT_ITEMCP__88P7C438",
                        column: x => x.IDProducto,
                        principalTable: "Product",
                        principalColumn: "PKID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cp_IDCustomer",
                table: "Cp",
                column: "IDCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCp_IDCp",
                table: "ItemCp",
                column: "IDCp");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCp_IDProducto",
                table: "ItemCp",
                column: "IDProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCp");

            migrationBuilder.DropTable(
                name: "Cp");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
