using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ApiAlunos.Migrations
{
    public partial class addColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Turma",
                table: "Alunos",
                nullable: true
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Turma",
                table: "Alunos"
            );
        }
    }
}
