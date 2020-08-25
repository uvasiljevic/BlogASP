using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.DataAccess.Migrations
{
    public partial class Migracija2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ArticlesRates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ArticlesRates_UserId",
                table: "ArticlesRates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticlesRates_Users_UserId",
                table: "ArticlesRates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticlesRates_Users_UserId",
                table: "ArticlesRates");

            migrationBuilder.DropIndex(
                name: "IX_ArticlesRates_UserId",
                table: "ArticlesRates");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ArticlesRates");
        }
    }
}
