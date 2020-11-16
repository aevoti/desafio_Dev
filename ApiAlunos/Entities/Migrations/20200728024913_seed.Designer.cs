﻿// <auto-generated />
using Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entities.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20200728024913_seed")]
    partial class seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Models.Aluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlunoId");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            AlunoId = 1,
                            Email = "douglass.sousa@outlook.com.br",
                            Nome = "Douglas Silva"
                        },
                        new
                        {
                            AlunoId = 2,
                            Email = "joao.neto@outlook.com.br",
                            Nome = "João Neto"
                        },
                        new
                        {
                            AlunoId = 3,
                            Email = "carlos.almeida@outlook.com.br",
                            Nome = "Carlos Almeida"
                        },
                        new
                        {
                            AlunoId = 4,
                            Email = "carlos.haha@outlook.com.br",
                            Nome = "Carlos de Nobrega"
                        },
                        new
                        {
                            AlunoId = 5,
                            Email = "douglas.correia@outlook.com.br",
                            Nome = "Douglas Correia"
                        },
                        new
                        {
                            AlunoId = 6,
                            Email = "pamela.albur@outlook.com.br",
                            Nome = "Pamela Albur"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
