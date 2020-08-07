using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DATOS.Migrations
{
    public partial class MicroservicioPublicacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comentarios = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ComentarioPublicacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComentariosID = table.Column<int>(nullable: false),
                    PublicacionID = table.Column<int>(nullable: false),
                    ComentarioNavigatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioPublicacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComentarioPublicacion_Comentarios_ComentarioNavigatorId",
                        column: x => x.ComentarioNavigatorId,
                        principalTable: "Comentarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComentarioPublicacion_Publicaciones_PublicacionID",
                        column: x => x.PublicacionID,
                        principalTable: "Publicaciones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioPublicacion_ComentarioNavigatorId",
                table: "ComentarioPublicacion",
                column: "ComentarioNavigatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioPublicacion_PublicacionID",
                table: "ComentarioPublicacion",
                column: "PublicacionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentarioPublicacion");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Publicaciones");
        }
    }
}
