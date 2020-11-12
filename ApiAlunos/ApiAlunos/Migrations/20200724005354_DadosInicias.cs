using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAlunos.Migrations
{
    public partial class DadosInicias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "Nome", "Email" },
                values: new object[] { 1, "Jonathan Ribeiro da Silva", "jota.ribeiro.silva@gmail.com" }
                );

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "Nome" , "Email" },
                values: new object[] { 2, "Luiza Belle Amorim", "luizaba@hotmail.com" }
                );

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "Nome", "Email" },
                values: new object[] { 3, "José Carlos Silveira", "ze_carloss@hotmail.com" }
                );

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "Nome", "Email" },
                values: new object[] { 4, "Ludimila Nunes", "ludingn@gmail.com" }
                );

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "Nome", "Email" },
                values: new object[] { 5, "Karoline Pereira", "karolp@gmail.com" }
                );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "AlunoId",
                keyValue: 1
                );

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "AlunoId",
                keyValue: 2
                );

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "AlunoId",
                keyValue: 3
                );

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "AlunoId",
                keyValue: 4
                );

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "AlunoId",
                keyValue: 5
                );
        }
    }
}
