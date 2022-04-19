using Microsoft.EntityFrameworkCore.Migrations;

namespace Volvo.Repository.Migrations
{
    public partial class Volvo0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_VOLVO_CAMINHAO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MODELO = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    ANO_FABRICACAO = table.Column<int>(type: "int", nullable: false),
                    ANO_MODELO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VOLVO_CAMINHAO", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_VOLVO_CAMINHAO");
        }
    }
}
