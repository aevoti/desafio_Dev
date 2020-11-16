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
                values: new object[,]
                {
                    { 1, "douglass.sousa@outlook.com.br", "Douglas Silva" },
                    { 2, "joao.neto@outlook.com.br", "João Neto" },
                    { 3, "carlos.almeida@outlook.com.br", "Carlos Almeida" },
                    { 4, "carlos.haha@outlook.com.br", "Carlos de Nobrega" },
                    { 5, "douglas.correia@outlook.com.br", "Douglas Correia" },
                    { 6, "pamela.albur@outlook.com.br", "Pamela Albur" }
                });
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

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "AlunoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "AlunoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "AlunoId",
                keyValue: 6);
        }
    }
}
