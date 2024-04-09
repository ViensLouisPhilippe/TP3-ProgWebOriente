using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlappyBirdTP3.Migrations
{
    public partial class Migrations_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Visible",
                table: "Score",
                newName: "IsPublic");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPublic",
                table: "Score",
                newName: "Visible");
        }
    }
}
