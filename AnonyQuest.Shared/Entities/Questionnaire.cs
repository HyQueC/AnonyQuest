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
        public string AuthorEmail { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório")]
        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório")]
        public DateTime EndDate { get; set; }
        
        public DateTime LatestUpdateDate { get; set; }

        public DateTime LatestEditDate { get; set; }

        public bool HasStarted { get; set; }

        public List<Question> Questions { get; set; }

        public List<ReceiverQuestionnaire> ReceiverQuestionnaires { get; set; }

        [NotMapped]
        public int TotalAnswerCount { get; set; }

        [NotMapped]
        public List<string> Destinatary { get; set; }
    }
}
