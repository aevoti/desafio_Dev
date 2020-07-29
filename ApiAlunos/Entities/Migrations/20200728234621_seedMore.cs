using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class seedMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "Email", "Nome" },
                values: new object[] { 7, "diogo.almeida@outlook.com.br", "Diogo Almeida" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "Email", "Nome" },
                values: new object[] { 8, "sac@outlook.com.br", "Samanta de Almeida Costa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "AlunoId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "AlunoId",
                keyValue: 8);
        }
    }
}
