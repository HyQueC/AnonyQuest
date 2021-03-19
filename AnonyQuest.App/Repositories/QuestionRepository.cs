using AnonyQuest.App.Data;
using AnonyQuest.Shared.Entities;
using System;
using System.Linq;

namespace AnonyQuest.App.Repositories
{
    public class QuestionRepository : GenericRepository<Question>
    {

        public QuestionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Question Update(Question entity)
        {
            var question = _context.Question.SingleOrDefault(q => q.Id == entity.Id);
            question.CreatedDate = entity.CreatedDate;
            question.Description = entity.Description;
            if (question.Description.Equals(entity.Description))
            {
                question.LatestEditDate = entity.LatestEditDate;
            }
            else
            {
                question.LatestEditDate = DateTime.Now;
            }
            if(question.Answers == null)
            {
                question.Answers = entity.Answers;
                _context.Entry(question.Answers.FirstOrDefault()).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
            {
                question.Answers = entity.Answers;
                _context.Entry(question.Answers.FirstOrDefault()).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return base.Update(question);
        }

    }

}
