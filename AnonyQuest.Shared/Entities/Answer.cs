using System;
using System.ComponentModel.DataAnnotations;

namespace AnonyQuest.Shared.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }

        public bool FinalAnswer { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LatestEditDate { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }

    }
}
