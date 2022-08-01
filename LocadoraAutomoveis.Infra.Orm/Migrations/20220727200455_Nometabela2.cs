using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    public partial class Nometabela2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCLIENTE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(20)", nullable: true),
                    Cnpj = table.Column<string>(type: "varchar(20)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    TipoCliente = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCLIENTE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBFUNCIONARIO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(120)", nullable: false),
                    Login = table.Column<string>(type: "varchar(50)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(50)", nullable: false),
                    Salario = table.Column<double>(type: "float", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "date", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(150)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: false),
                    Perfil = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFUNCIONARIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBGRUPOVEICULO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGRUPOVEICULO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBCONDUTOR",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(20)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    Cnh = table.Column<string>(type: "varchar(20)", nullable: false),
                    VencimentoCnh = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCONDUTOR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCONDUTOR_TBCLIENTE_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBCLIENTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBPLANO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoVeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorDiario_Diario = table.Column<double>(type: "float", nullable: false),
                    ValorPorKm_Diario = table.Column<double>(type: "float", nullable: false),
                    ValorDiario_Livre = table.Column<double>(type: "float", nullable: false),
                    ValorDiario_Controlado = table.Column<double>(type: "float", nullable: false),
                    ValorPorKm_Controlado = table.Column<double>(type: "float", nullable: false),
                    LimiteQuilometragem_Controlado = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPLANO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPLANO_TBGRUPOVEICULO_GrupoVeiculoId",
                        column: x => x.GrupoVeiculoId,
                        principalTable: "TBGRUPOVEICULO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBVEICULO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(250)", nullable: false),
                    Placa = table.Column<string>(type: "varchar(10)", nullable: false),
                    Cor = table.Column<string>(type: "varchar(50)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    TipoCombustivel = table.Column<string>(type: "varchar(50)", nullable: false),
                    CapacidadeTanque = table.Column<double>(type: "float", nullable: false),
                    GrupoPertencenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StatusVeiculo = table.Column<string>(type: "varchar(50)", nullable: false),
                    QuilometragemAtual = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVEICULO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBVEICULO_TBGRUPOVEICULO_GrupoPertencenteId",
                        column: x => x.GrupoPertencenteId,
                        principalTable: "TBGRUPOVEICULO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBLOCACAO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoLocacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoLocacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteLocacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondutorLocacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataLocacao = table.Column<DateTime>(type: "date", nullable: false),
                    DataDevolucao = table.Column<string>(type: "varchar(50)", nullable: false),
                    PlanoLocacao_Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLOCACAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLOCACAO_TBCLIENTE_ClienteLocacaoId",
                        column: x => x.ClienteLocacaoId,
                        principalTable: "TBCLIENTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLOCACAO_TBCONDUTOR_CondutorLocacaoId",
                        column: x => x.CondutorLocacaoId,
                        principalTable: "TBCONDUTOR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLOCACAO_TBPLANO_PlanoLocacaoId",
                        column: x => x.PlanoLocacaoId,
                        principalTable: "TBPLANO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLOCACAO_TBVEICULO_VeiculoLocacaoId",
                        column: x => x.VeiculoLocacaoId,
                        principalTable: "TBVEICULO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBTAXA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(20)", nullable: false),
                    LocacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTAXA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBTAXA_TBLOCACAO_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "TBLOCACAO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBCONDUTOR_ClienteId",
                table: "TBCONDUTOR",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLOCACAO_ClienteLocacaoId",
                table: "TBLOCACAO",
                column: "ClienteLocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLOCACAO_CondutorLocacaoId",
                table: "TBLOCACAO",
                column: "CondutorLocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLOCACAO_PlanoLocacaoId",
                table: "TBLOCACAO",
                column: "PlanoLocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLOCACAO_VeiculoLocacaoId",
                table: "TBLOCACAO",
                column: "VeiculoLocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBPLANO_GrupoVeiculoId",
                table: "TBPLANO",
                column: "GrupoVeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBTAXA_LocacaoId",
                table: "TBTAXA",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBVEICULO_GrupoPertencenteId",
                table: "TBVEICULO",
                column: "GrupoPertencenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBFUNCIONARIO");

            migrationBuilder.DropTable(
                name: "TBTAXA");

            migrationBuilder.DropTable(
                name: "TBLOCACAO");

            migrationBuilder.DropTable(
                name: "TBCONDUTOR");

            migrationBuilder.DropTable(
                name: "TBPLANO");

            migrationBuilder.DropTable(
                name: "TBVEICULO");

            migrationBuilder.DropTable(
                name: "TBCLIENTE");

            migrationBuilder.DropTable(
                name: "TBGRUPOVEICULO");
        }
    }
}
