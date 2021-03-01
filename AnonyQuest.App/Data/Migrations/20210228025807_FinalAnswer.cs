using Microsoft.EntityFrameworkCore.Migrations;

namespace AnonyQuest.App.Data.Migrations
{
    public partial class FinalAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FinalAnswer",
                table: "Answer",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalAnswer",
                table: "Answer");
        }
    }
}
