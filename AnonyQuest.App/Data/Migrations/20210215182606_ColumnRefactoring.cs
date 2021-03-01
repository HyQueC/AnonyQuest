using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnonyQuest.App.Data.Migrations
{
    public partial class ColumnRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenTime",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Question");

            migrationBuilder.AddColumn<string>(
                name: "AuthorEmail",
                table: "Questionnaire",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Questionnaire",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "HasStarted",
                table: "Questionnaire",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorEmail",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "HasStarted",
                table: "Questionnaire");

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenTime",
                table: "Questionnaire",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Question",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
