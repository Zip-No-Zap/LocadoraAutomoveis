using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    public partial class addCampoNivelTanque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NivelTanqueVeiculo",
                table: "TBLOCACAO",
                type: "varchar(10)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NivelTanqueVeiculo",
                table: "TBLOCACAO");
        }
    }
}
