﻿// <auto-generated />
using ERPPRO.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ERPPRO.API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250210165734_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ERPPRO.API.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cargo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Celular")
                        .HasColumnType("TEXT");

                    b.Property<string>("DataAdimissao")
                        .HasColumnType("TEXT");

                    b.Property<string>("DataDemissao")
                        .HasColumnType("TEXT");

                    b.Property<string>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("HorarioEntrada")
                        .HasColumnType("TEXT");

                    b.Property<string>("HorarioSaida")
                        .HasColumnType("TEXT");

                    b.Property<string>("NivelAcesso")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("TEXT");

                    b.Property<string>("Salario")
                        .HasColumnType("TEXT");

                    b.Property<string>("Setor")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
                });
#pragma warning restore 612, 618
        }
    }
}
