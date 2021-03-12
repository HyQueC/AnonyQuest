using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnonyQuest.App.Data.Migrations
{
    public partial class RemoveLatestEditDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatestEditDate",
                table: "Questionnaire");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LatestEditDate",
                table: "Questionnaire",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
