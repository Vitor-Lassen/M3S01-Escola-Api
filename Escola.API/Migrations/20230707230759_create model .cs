using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Escola.API.Migrations
{
    public partial class createmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BOLETIM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA = table.Column<DateTime>(type: "date", nullable: false),
                    AlunoId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOLETIM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BOLETIM_AlunoTB_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "AlunoTB",
                        principalColumn: "PK_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotasMateria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoletimId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasMateria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotasMateria_BOLETIM_BoletimId",
                        column: x => x.BoletimId,
                        principalTable: "BOLETIM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotasMateria_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOLETIM_AlunoId",
                table: "BOLETIM",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasMateria_BoletimId",
                table: "NotasMateria",
                column: "BoletimId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasMateria_MateriaId",
                table: "NotasMateria",
                column: "MateriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotasMateria");

            migrationBuilder.DropTable(
                name: "BOLETIM");

            migrationBuilder.DropTable(
                name: "Materia");
        }
    }
}
