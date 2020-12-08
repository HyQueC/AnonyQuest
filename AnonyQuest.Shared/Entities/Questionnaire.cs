using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnonyQuest.Shared.Entities
{
    public class Questionnaire
    {
        public int Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório")]
        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime OpenTime { get; set; }
        
        public DateTime LatestUpdateDate { get; set; }

        public DateTime LatestEditDate { get; set; }

        public List<Question> Questions { get; set; }

        public List<ReceiverQuestionnaire> ReceiverQuestionnaires { get; set; }

        [NotMapped]
        public string UserName { get; set; }

        [NotMapped]
        public int TotalAnswerCount { get; set; }

        [NotMapped]
        public List<string> Destinatary { get; set; }
    }
}
