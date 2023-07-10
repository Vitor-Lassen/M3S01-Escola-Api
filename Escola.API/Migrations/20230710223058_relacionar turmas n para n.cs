using Microsoft.EntityFrameworkCore.Migrations;

namespace Escola.API.Migrations
{
    public partial class relacionarturmasnparan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ALUNO_X_TURMA",
                columns: table => new
                {
                    ALUNO_ID = table.Column<int>(type: "int", nullable: false),
                    TURMA_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALUNO_X_TURMA", x => new { x.ALUNO_ID, x.TURMA_ID });
                    table.ForeignKey(
                        name: "FK_ALUNO_X_TURMA_AlunoTB_ALUNO_ID",
                        column: x => x.ALUNO_ID,
                        principalTable: "AlunoTB",
                        principalColumn: "PK_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ALUNO_X_TURMA_TURMA_TURMA_ID",
                        column: x => x.TURMA_ID,
                        principalTable: "TURMA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALUNO_X_TURMA_TURMA_ID",
                table: "ALUNO_X_TURMA",
                column: "TURMA_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALUNO_X_TURMA");
        }
    }
}
