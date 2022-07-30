using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdoApi.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Importance",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "prefix",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "prefixId",
                table: "Cards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ImportanceId",
                table: "Cards",
                column: "ImportanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_prefixId",
                table: "Cards",
                column: "prefixId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Importances_ImportanceId",
                table: "Cards",
                column: "ImportanceId",
                principalTable: "Importances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_States_prefixId",
                table: "Cards",
                column: "prefixId",
                principalTable: "States",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Importances_ImportanceId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_States_prefixId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_ImportanceId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_prefixId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "prefixId",
                table: "Cards");

            migrationBuilder.AddColumn<string>(
                name: "Importance",
                table: "Cards",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "prefix",
                table: "Cards",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
