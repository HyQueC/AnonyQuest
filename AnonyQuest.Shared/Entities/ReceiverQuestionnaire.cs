namespace AnonyQuest.Shared.Entities
{
    public class ReceiverQuestionnaire
    {
        public string UserEmail { get; set; }
        public int QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }

    }
}
