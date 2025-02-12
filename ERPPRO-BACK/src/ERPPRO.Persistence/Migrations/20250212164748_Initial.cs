using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPPRO.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCompleto = table.Column<string>(type: "TEXT", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CPF = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Celular = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Setor = table.Column<string>(type: "TEXT", nullable: true),
                    Cargo = table.Column<string>(type: "TEXT", nullable: true),
                    Salario = table.Column<string>(type: "TEXT", nullable: true),
                    DataAdimissao = table.Column<string>(type: "TEXT", nullable: true),
                    DataDemissao = table.Column<string>(type: "TEXT", nullable: true),
                    HorarioEntrada = table.Column<string>(type: "TEXT", nullable: true),
                    HorarioSaida = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NivelAcessos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    bloqueios = table.Column<string>(type: "TEXT", nullable: true),
                    inicial = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelAcessos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comunicacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: true),
                    Setor = table.Column<string>(type: "TEXT", nullable: true),
                    Mensagem = table.Column<string>(type: "TEXT", nullable: true),
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunicacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comunicacoes_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comunicacoes_FuncionarioId",
                table: "Comunicacoes",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comunicacoes");

            migrationBuilder.DropTable(
                name: "NivelAcessos");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
