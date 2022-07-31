using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    public partial class addItensTaxaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDevolucao",
                table: "TBLOCACAO",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDevolvidoDeFato",
                table: "TBLOCACAO",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "GrupoId",
                table: "TBLOCACAO",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ItensTaxaId",
                table: "TBLOCACAO",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrevisto",
                table: "TBLOCACAO",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_TBLOCACAO_GrupoId",
                table: "TBLOCACAO",
                column: "GrupoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBLOCACAO_TBGRUPOVEICULO_GrupoId",
                table: "TBLOCACAO",
                column: "GrupoId",
                principalTable: "TBGRUPOVEICULO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBLOCACAO_TBGRUPOVEICULO_GrupoId",
                table: "TBLOCACAO");

            migrationBuilder.DropIndex(
                name: "IX_TBLOCACAO_GrupoId",
                table: "TBLOCACAO");

            migrationBuilder.DropColumn(
                name: "DataDevolvidoDeFato",
                table: "TBLOCACAO");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "TBLOCACAO");

            migrationBuilder.DropColumn(
                name: "ItensTaxaId",
                table: "TBLOCACAO");

            migrationBuilder.DropColumn(
                name: "TotalPrevisto",
                table: "TBLOCACAO");

            migrationBuilder.AlterColumn<string>(
                name: "DataDevolucao",
                table: "TBLOCACAO",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
