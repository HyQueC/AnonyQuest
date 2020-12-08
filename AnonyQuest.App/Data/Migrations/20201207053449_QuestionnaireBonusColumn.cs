using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnonyQuest.App.Data.Migrations
{
    public partial class QuestionnaireBonusColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LatestUpdateDate",
                table: "Questionnaire",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenTime",
                table: "Questionnaire",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatestUpdateDate",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "OpenTime",
                table: "Questionnaire");
        }
    }
}
