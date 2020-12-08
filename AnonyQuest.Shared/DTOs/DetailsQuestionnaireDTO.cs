using AnonyQuest.Shared.Entities;
using System;
using System.Collections.Generic;

namespace AnonyQuest.Shared.DTOs
{
    public class DetailsQuestionnaireDTO
    {
        public Questionnaire Questionnaire { get; set; }
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
