using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdoApi.Migrations
{
    public partial class InitialCreate7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EstimateUnit",
                table: "Cards",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimateUnit",
                table: "Cards");
        }
    }
}
