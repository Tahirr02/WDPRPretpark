using Microsoft.EntityFrameworkCore.Migrations;

namespace WdprPretparkDenhaag.Migrations
{
    public partial class migratieDatabasescaffold124lljjktytyuhkhkujygtjygtjytjyjfjyfyj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Tijdsloten",
                newName: "BeginTijd");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BeginTijd",
                table: "Tijdsloten",
                newName: "MyProperty");
        }
    }
}
