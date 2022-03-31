using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoIdiomas.API.Persistance.MatriculaMigrations
{
    public partial class AdicionadoMatricula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Turmas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MatriculaId",
                table: "Turmas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_AlunoId",
                table: "Turmas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_MatriculaId",
                table: "Turmas",
                column: "MatriculaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Alunos_AlunoId",
                table: "Turmas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Matriculas_MatriculaId",
                table: "Turmas",
                column: "MatriculaId",
                principalTable: "Matriculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Alunos_AlunoId",
                table: "Turmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Matriculas_MatriculaId",
                table: "Turmas");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropIndex(
                name: "IX_Turmas_AlunoId",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Turmas_MatriculaId",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "MatriculaId",
                table: "Turmas");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
