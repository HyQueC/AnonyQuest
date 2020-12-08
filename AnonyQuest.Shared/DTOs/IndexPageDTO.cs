using AnonyQuest.Shared.Entities;
using System.Collections.Generic;

namespace AnonyQuest.Shared.DTOs
{
    public class IndexPageDTO
    {
        public List<Questionnaire> PersonalQuestionnaires { get; set; }
        public List<Questionnaire> ReceivedQuestionnaires { get; set; }
    }
}
