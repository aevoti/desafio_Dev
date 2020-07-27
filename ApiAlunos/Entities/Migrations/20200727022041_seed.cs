using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "Email", "Nome" },
                values: new object[] { 1, "douglass.sousa@outlook.com.br", "Douglas Silva" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "Email", "Nome" },
                values: new object[] { 2, "joao.neto@outlook.com.br", "João Neto" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "Email", "Nome" },
                values: new object[] { 3, "carlos.almeida@outlook.com.br", "Carlos Almeida" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "AlunoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "AlunoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "AlunoId",
                keyValue: 3);
        }
    }
}
