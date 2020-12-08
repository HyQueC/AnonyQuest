using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnonyQuest.Shared.Entities
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public string Picture { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LatestEditDate { get; set; }

        public List<Answer> Answers { get; set; }

        public int QuestionnaireId { get; set; }

        public Questionnaire Questionnaire { get; set; }
    }
}
