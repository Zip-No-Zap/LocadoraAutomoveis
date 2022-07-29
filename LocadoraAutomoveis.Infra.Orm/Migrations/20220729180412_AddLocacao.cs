using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    public partial class AddLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocacaoId",
                table: "TBTAXA",
                type: "uniqueidentifier",
                nullable: true);

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
                    PlanoLocacao_Descricao = table.Column<string>(type: "varchar(20)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_TBTAXA_LocacaoId",
                table: "TBTAXA",
                column: "LocacaoId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TBTAXA_TBLOCACAO_LocacaoId",
                table: "TBTAXA",
                column: "LocacaoId",
                principalTable: "TBLOCACAO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBTAXA_TBLOCACAO_LocacaoId",
                table: "TBTAXA");

            migrationBuilder.DropTable(
                name: "TBLOCACAO");

            migrationBuilder.DropIndex(
                name: "IX_TBTAXA_LocacaoId",
                table: "TBTAXA");

            migrationBuilder.DropColumn(
                name: "LocacaoId",
                table: "TBTAXA");
        }
    }
}
