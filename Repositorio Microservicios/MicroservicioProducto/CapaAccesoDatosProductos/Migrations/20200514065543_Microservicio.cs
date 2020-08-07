using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CapaAccesoDatosProductos.Migrations
{
    public partial class Microservicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "imagenproducto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagenproducto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "marca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "precioproducto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precioreal = table.Column<decimal>(nullable: false),
                    Precioventa = table.Column<decimal>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_precioproducto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    PrecioID = table.Column<int>(nullable: false),
                    ImagenID = table.Column<int>(nullable: false),
                    CategoriaID = table.Column<int>(nullable: false),
                    MarcaID = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    ImagenProductoNavigatorId = table.Column<int>(nullable: true),
                    PrecioProductoNavigatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productos_categorias_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productos_imagenproducto_ImagenProductoNavigatorId",
                        column: x => x.ImagenProductoNavigatorId,
                        principalTable: "imagenproducto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_productos_marca_MarcaID",
                        column: x => x.MarcaID,
                        principalTable: "marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productos_precioproducto_PrecioProductoNavigatorId",
                        column: x => x.PrecioProductoNavigatorId,
                        principalTable: "precioproducto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productos_CategoriaID",
                table: "productos",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_productos_ImagenProductoNavigatorId",
                table: "productos",
                column: "ImagenProductoNavigatorId");

            migrationBuilder.CreateIndex(
                name: "IX_productos_MarcaID",
                table: "productos",
                column: "MarcaID");

            migrationBuilder.CreateIndex(
                name: "IX_productos_PrecioProductoNavigatorId",
                table: "productos",
                column: "PrecioProductoNavigatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "imagenproducto");

            migrationBuilder.DropTable(
                name: "marca");

            migrationBuilder.DropTable(
                name: "precioproducto");
        }
    }
}
