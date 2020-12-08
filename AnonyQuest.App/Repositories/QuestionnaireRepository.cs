using AnonyQuest.App.Data;
using AnonyQuest.App.Helpers;
using AnonyQuest.Shared.DTOs;
using AnonyQuest.Shared.Entities;
using AnonyQuest.Shared.Repositories;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace AnonyQuest.App.Repositories
{
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IAuthenticationStateService authenticationStateService;

        public QuestionnaireRepository(ApplicationDbContext context,
           IAuthenticationStateService authenticationStateService)
        {
            this.context = context;
            this.authenticationStateService = authenticationStateService;
        }

        public async Task<int> CreateQuestionnaire(Questionnaire questionnaire)
        {
            var userEmail = await authenticationStateService.GetCurrentUserEmail();

            questionnaire.Email = userEmail;
            context.Add(questionnaire);
            await context.SaveChangesAsync();
            return questionnaire.Id;
        }

        public async Task DeleteQuestionnaire(int Id)
        {
            var questionnaire = await context.Questionnaire.FindAsync(Id);
            context.Remove(questionnaire);
            await context.SaveChangesAsync();
        }

        public async Task<DetailsQuestionnaireDTO> GetDetailsQuestionnaireDTO(int id)
        {
            var questionnaire = await context.Questionnaire.Where(x => x.Id == id)
                .Include(x => x.Questions).ThenInclude(x => x.Answers)
                .Include(x => x.ReceiverQuestionnaires)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (questionnaire == null) { return null; }


            //if (await context.QuestionnaireRatings.AnyAsync(x => x.QuestionnaireId == id))
            {
                //voteAverage = await context.QuestionnaireRatings.Where(x => x.QuestionnaireId == id)
                //    .AverageAsync(x => x.Rate);

                var userId = await authenticationStateService.GetCurrentUserId();

                if (userId != null)
                {
                    //var userVoteDB = await context.QuestionnaireRatings
                    //    .FirstOrDefaultAsync(x => x.QuestionnaireId == id && x.UserId == userId);

                    //if (userVoteDB != null)
                    //{
                    //    uservote = userVoteDB.Rate;
                    //}
                }
            }

            //Questionnaire.QuestionnairesActors = Questionnaire.QuestionnairesActors.OrderBy(x => x.Order).ToList();

            var model = new DetailsQuestionnaireDTO();
            //model.Questionnaire = Questionnaire;
            //model.Genres = Questionnaire.QuestionnairesGenres.Select(x => x.Genre).ToList();
            //model.Actors = Questionnaire.QuestionnairesActors.Select(x =>
            //    new Person
            //    {
            //        Name = x.Person.Name,
            //        Picture = x.Person.Picture,
            //        Character = x.Character,
            //        Id = x.PersonId

            //    }).ToList();

            return model;
        }

        public async Task<IndexPageDTO> GetIndexPageDTO()
        {
            var limit = 6;
            var userEmail = await authenticationStateService.GetCurrentUserEmail();

            if(userEmail == null) { return null; }

            var personalQuestionnaires = await context.Questionnaire
                .Where(x => x.Email == userEmail).Take(limit)
                .OrderByDescending(x => x.LatestUpdateDate)
                .AsNoTracking()
                .ToListAsync();

            var userId = await authenticationStateService.GetCurrentUserId();

            var receivedQuestionnaires = await context.ReceiverQuestionnaire
                .Where(x => x.UserId.ToString() == userId)
                .AsNoTracking()
                .ToListAsync();

            var response = new IndexPageDTO();
            response.PersonalQuestionnaires = personalQuestionnaires;
            response.ReceivedQuestionnaires = receivedQuestionnaires.Select(q => q.Questionnaire).OrderBy(q=> q.LatestUpdateDate).ToList(); ;

            return response;
        }

        //public async Task<QuestionnaireUpdateDTO> GetQuestionnaireForUpdate(int id)
        //{
        //    var questionnaireDetailDTO = await GetDetailsQuestionnaireDTO(id);

        //    if (questionnaireDetailDTO == null) { return null; }

        //    //var selectedGenresIds = QuestionnaireDetailDTO.Genres.Select(x => x.Id).ToList();
        //    //var notSelectedGenres = await context.Genres
        //    //    .Where(x => !selectedGenresIds.Contains(x.Id))
        //    //    .ToListAsync();

        //    var model = new QuestionnaireUpdateDTO();
        //    model.Questionnaire = questionnaireDetailDTO.Questionnaire;
        //    //model.NotSelectedGenres = notSelectedGenres;
        //    return model;
        //}

        //public async Task<PaginatedResponse<List<Questionnaire>>> GetQuestionnairesFiltered(FilterQuestionnairesDTO filterQuestionnairesDTO)
        //{
        //    //var QuestionnairesQueryable = context.Questionnaires.AsQueryable();

        //    //if (!string.IsNullOrWhiteSpace(filterQuestionnairesDTO.Title))
        //    //{
        //    //    QuestionnairesQueryable = QuestionnairesQueryable
        //    //        .Where(x => x.Title.Contains(filterQuestionnairesDTO.Title));
        //    //}

        //    //if (filterQuestionnairesDTO.InTheaters)
        //    //{
        //    //    QuestionnairesQueryable = QuestionnairesQueryable.Where(x => x.InTheaters);
        //    //}

        //    //if (filterQuestionnairesDTO.UpcomingReleases)
        //    //{
        //    //    var today = DateTime.Today;
        //    //    QuestionnairesQueryable = QuestionnairesQueryable.Where(x => x.ReleaseDate > today);
        //    //}

        //    //if (filterQuestionnairesDTO.GenreId != 0)
        //    //{
        //    //    QuestionnairesQueryable = QuestionnairesQueryable
        //    //        .Where(x => x.QuestionnairesGenres.Select(y => y.GenreId)
        //    //        .Contains(filterQuestionnairesDTO.GenreId));
        //    //}

        //    //var Questionnaires = await QuestionnairesQueryable.GetPaginatedResponse(filterQuestionnairesDTO.Pagination);
        //    //return Questionnaires;
        //    return null;
        //}

        //public async Task UpdateQuestionnaire(Questionnaire Questionnaire)
        //{
        //    context.Entry(Questionnaire).State = EntityState.Detached;
        //    //var QuestionnaireDB = await context.Questionnaires
        //    //    .Include(x => x.QuestionnairesActors)
        //    //    .Include(x => x.QuestionnairesGenres)
        //    //    .FirstOrDefaultAsync(x => x.Id == Questionnaire.Id);

        //    if (!string.IsNullOrWhiteSpace(Questionnaire.Poster))
        //    {
        //        //var QuestionnairePoster = Convert.FromBase64String(Questionnaire.Poster);
        //        //QuestionnaireDB.Poster = await fileStorageService.EditFile(QuestionnairePoster,
        //        //    "jpg", containerName, QuestionnaireDB.Poster);
        //    }

        //    if (Questionnaire.QuestionnairesActors != null)
        //    {
        //        for (int i = 0; i < Questionnaire.QuestionnairesActors.Count; i++)
        //        {
        //            Questionnaire.QuestionnairesActors[i].Order = i + 1;
        //        }
        //    }

        //    //QuestionnaireDB.QuestionnairesActors = Questionnaire.QuestionnairesActors;
        //    //QuestionnaireDB.QuestionnairesGenres = Questionnaire.QuestionnairesGenres;

        //    await context.SaveChangesAsync();
        //}
    }
}
