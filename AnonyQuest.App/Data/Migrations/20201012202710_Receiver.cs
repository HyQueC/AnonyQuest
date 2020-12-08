using Microsoft.EntityFrameworkCore.Migrations;

namespace AnonyQuest.App.Data.Migrations
{
    public partial class Receiver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReceiverQuestionnaire",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    QuestionnaireId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiverQuestionnaire", x => new { x.UserId, x.QuestionnaireId });
                    table.ForeignKey(
                        name: "FK_ReceiverQuestionnaire_Questionnaire_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "Questionnaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverQuestionnaire_QuestionnaireId",
                table: "ReceiverQuestionnaire",
                column: "QuestionnaireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceiverQuestionnaire");
        }
    }
}
