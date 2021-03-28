using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ApiAlunos.Migrations
{
    public partial class addColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Alunos",
                nullable: true
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Alunos"
            );
        }
    }
}
