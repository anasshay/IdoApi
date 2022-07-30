using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdoApi.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Importances_ImportanceId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_States_StateId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_ImportanceId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_StateId",
                table: "Cards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cards_ImportanceId",
                table: "Cards",
                column: "ImportanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_StateId",
                table: "Cards",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Importances_ImportanceId",
                table: "Cards",
                column: "ImportanceId",
                principalTable: "Importances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_States_StateId",
                table: "Cards",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
