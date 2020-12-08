namespace AnonyQuest.Shared.Entities
{
    public class ReceiverQuestionnaire
    {
        public int UserId { get; set; }
        public int QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }
    }
}
