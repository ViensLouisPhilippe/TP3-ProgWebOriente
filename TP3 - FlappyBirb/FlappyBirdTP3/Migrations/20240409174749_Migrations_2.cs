using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlappyBirdTP3.Migrations
{
    public partial class Migrations_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Temps",
                table: "Score",
                newName: "TimeInSeconds");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeInSeconds",
                table: "Score",
                newName: "Temps");
        }
    }
}
