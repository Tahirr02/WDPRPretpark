using Microsoft.EntityFrameworkCore.Migrations;

namespace WdprPretparkDenhaag.Migrations
{
    public partial class migratieDatabasescaffold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attracties_AspNetUsers_ApplicationUserId",
                table: "Attracties");

            migrationBuilder.DropForeignKey(
                name: "FK_Bezoekers_AspNetUsers_ApplicationUserId",
                table: "Bezoekers");

            migrationBuilder.DropForeignKey(
                name: "FK_Planningen_AspNetUsers_ApplicationUserId",
                table: "Planningen");

            migrationBuilder.DropForeignKey(
                name: "FK_Tijdsloten_AspNetUsers_ApplicationUserId",
                table: "Tijdsloten");

            migrationBuilder.DropIndex(
                name: "IX_Tijdsloten_ApplicationUserId",
                table: "Tijdsloten");

            migrationBuilder.DropIndex(
                name: "IX_Planningen_ApplicationUserId",
                table: "Planningen");

            migrationBuilder.DropIndex(
                name: "IX_Bezoekers_ApplicationUserId",
                table: "Bezoekers");

            migrationBuilder.DropIndex(
                name: "IX_Attracties_ApplicationUserId",
                table: "Attracties");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Tijdsloten");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Planningen");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Bezoekers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Attracties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Tijdsloten",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Planningen",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Bezoekers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Attracties",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tijdsloten_ApplicationUserId",
                table: "Tijdsloten",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Planningen_ApplicationUserId",
                table: "Planningen",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bezoekers_ApplicationUserId",
                table: "Bezoekers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Attracties_ApplicationUserId",
                table: "Attracties",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attracties_AspNetUsers_ApplicationUserId",
                table: "Attracties",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bezoekers_AspNetUsers_ApplicationUserId",
                table: "Bezoekers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Planningen_AspNetUsers_ApplicationUserId",
                table: "Planningen",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tijdsloten_AspNetUsers_ApplicationUserId",
                table: "Tijdsloten",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
