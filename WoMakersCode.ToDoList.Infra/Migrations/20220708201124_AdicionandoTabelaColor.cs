using Microsoft.EntityFrameworkCore.Migrations;

namespace WoMakersCode.TodoList.Infra.Migrations
{
    public partial class AdicionandoTabelaColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdColor",
                table: "tasklists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tasklists_IdColor",
                table: "tasklists",
                column: "IdColor",
                unique: true,
                filter: "[IdColor] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_tasklists_colors_IdColor",
                table: "tasklists",
                column: "IdColor",
                principalTable: "colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasklists_colors_IdColor",
                table: "tasklists");

            migrationBuilder.DropTable(
                name: "colors");

            migrationBuilder.DropIndex(
                name: "IX_tasklists_IdColor",
                table: "tasklists");

            migrationBuilder.DropColumn(
                name: "IdColor",
                table: "tasklists");
        }
    }
}
