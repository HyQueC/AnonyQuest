using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnonyQuest.Shared.Entities
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
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
