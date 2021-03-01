using Microsoft.EntityFrameworkCore.Migrations;

namespace AnonyQuest.App.Data.Migrations
{
    public partial class AtualizacaoChaveReceiverQuestionnaire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiverQuestionnaire",
                table: "ReceiverQuestionnaire");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ReceiverQuestionnaire");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "ReceiverQuestionnaire",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiverQuestionnaire",
                table: "ReceiverQuestionnaire",
                columns: new[] { "UserEmail", "QuestionnaireId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiverQuestionnaire",
                table: "ReceiverQuestionnaire");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "ReceiverQuestionnaire");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ReceiverQuestionnaire",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiverQuestionnaire",
                table: "ReceiverQuestionnaire",
                columns: new[] { "UserId", "QuestionnaireId" });
        }
    }
}
