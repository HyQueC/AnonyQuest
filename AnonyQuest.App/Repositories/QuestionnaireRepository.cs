using AnonyQuest.App.Data;
using AnonyQuest.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Threading.Tasks;
using AnonyQuest.Shared.DTOs;
using AnonyQuest.Shared.Interfaces;

namespace AnonyQuest.App.Repositories
{
    public class QuestionnaireRepository : GenericRepository<Questionnaire>, IQuestionnaireRepository
    {

        public QuestionnaireRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Questionnaire> GetDetailsByUserAsync(int id, string currentUser)
        {
            IQueryable<Questionnaire> query;

            var questionnaireAuthor = await _context
                .Questionnaire.Where(x => x.Id == id)
                .Include(q => q.ReceiverQuestionnaires)
                .AsNoTracking()
                .FirstOrDefaultAsync();


            if (questionnaireAuthor.AuthorEmail.Equals(currentUser))
            {
                query = from questionnaire in _context.Questionnaire
                        where questionnaire.Id == id && questionnaire.AuthorEmail.Equals(currentUser)
                        select new Questionnaire()
                        {
                            Id = questionnaire.Id,
                            AuthorEmail = questionnaire.AuthorEmail,
                            Title = questionnaire.Title,
                            CreatedDate = questionnaire.CreatedDate,
                            EndDate = questionnaire.EndDate,
                            LatestUpdateDate = questionnaire.LatestUpdateDate,
                            HasStarted = questionnaire.HasStarted,
                            ReceiverQuestionnaires = questionnaire.ReceiverQuestionnaires,
                            Questions = (from question in _context.Question
                                         where question.QuestionnaireId == questionnaire.Id
                                         select new Question()
                                         {
                                             Id = question.Id,
                                             Description = question.Description,
                                             CreatedDate = question.CreatedDate,
                                             LatestEditDate = question.LatestEditDate,
                                             QuestionnaireId = question.QuestionnaireId,
                                             Questionnaire = question.Questionnaire,
                                             Answers = (from answer in _context.Answer
                                                        where answer.QuestionId == question.Id
                                                        && answer.FinalAnswer == true
                                                        select answer).OrderBy(a => a.UserEmail).ToList()
                                         }).ToList()
                        };
            }
            else if(questionnaireAuthor.ReceiverQuestionnaires.Any(r => r.ReceiverEmail.Equals(currentUser)))
            {
                query = from questionnaire in _context.Questionnaire
                        where questionnaire.Id == id
                        select new Questionnaire()
                        {
                            Id = questionnaire.Id,
                            AuthorEmail = questionnaire.AuthorEmail,
                            Title = questionnaire.Title,
                            CreatedDate = questionnaire.CreatedDate,
                            EndDate = questionnaire.EndDate,
                            LatestUpdateDate = questionnaire.LatestUpdateDate,
                            HasStarted = true,
                            Questions = (from question in _context.Question
                                         where question.QuestionnaireId == questionnaire.Id
                                         select new Question()
                                         {
                                             Id = question.Id,
                                             Description = question.Description,
                                             CreatedDate = question.CreatedDate,
                                             LatestEditDate = question.LatestEditDate,
                                             QuestionnaireId = question.QuestionnaireId,
                                             Questionnaire = question.Questionnaire,
                                             Answers = (from answer in _context.Answer
                                                        where answer.QuestionId == question.Id
                                                        && answer.UserEmail.Equals(currentUser)
                                                        select answer).OrderBy(a => a.UserEmail).ToList()
                                         }).ToList()
                        };
            }
            else
            {
                return new Questionnaire() { Id = -1};
            }

            return await query.FirstOrDefaultAsync();
        }

        public override Questionnaire Update(Questionnaire entity)
        {
            var questionnaire = _context.Questionnaire.SingleOrDefault(q => q.Id == entity.Id);

            questionnaire.HasStarted = entity.HasStarted;
            questionnaire.EndDate = entity.EndDate;
            questionnaire.Destinatary = entity.Destinatary;
            questionnaire.LatestUpdateDate = entity.LatestUpdateDate;
            questionnaire.LatestAnswerDate = entity.LatestAnswerDate;
            questionnaire.TotalAnswerCount = entity.TotalAnswerCount;
            questionnaire.Title = entity.Title;
            questionnaire.Questions = entity.Questions;
            return base.Update(questionnaire);
        }

        public override async Task<Questionnaire> AddAsync(Questionnaire entity)
        {
            return await base.AddAsync(entity);
        }

        public async Task<IndexPageDTO> GetIndexPageDTO(string userEmail)
        {
            if (userEmail == null) { return null; }

            var personalQuestionnaires = await _context.Questionnaire
                .Where(x => x.AuthorEmail == userEmail)
                .Include(q => q.ReceiverQuestionnaires)
                .OrderByDescending(x => x.LatestUpdateDate)
                .AsNoTracking()
                .ToListAsync();
            
            var receivedQuestionnaires = await _context.ReceiverQuestionnaire
                .Include(rq => rq.Questionnaire)
                .Where(x => x.ReceiverEmail == userEmail)
                .Where(x => x.Questionnaire.HasStarted == true)
                .AsNoTracking()
                .ToListAsync();

            var response = new IndexPageDTO
            {
                PersonalQuestionnaires = personalQuestionnaires,
                ReceivedQuestionnaires = receivedQuestionnaires.Select(q => q.Questionnaire).OrderByDescending(q => q.LatestUpdateDate).ToList()
            };

            return response;
        }

    }
}
