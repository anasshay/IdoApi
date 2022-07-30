using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdoApi.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Users_UserId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_UserId",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "Cards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserModelId",
                table: "Cards",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Users_UserModelId",
                table: "Cards",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Users_UserModelId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_UserModelId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "Cards");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserId",
                table: "Cards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Users_UserId",
                table: "Cards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
