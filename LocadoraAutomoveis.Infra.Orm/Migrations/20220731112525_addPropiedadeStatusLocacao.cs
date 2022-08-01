using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    public partial class addPropiedadeStatusLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "TBLOCACAO",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TBLOCACAO");
        }
    }
}
