using AnonyQuest.Shared.DTOs;
using AnonyQuest.Shared.Entities;
using System.Threading.Tasks;

namespace AnonyQuest.Shared.Repositories
{
    public interface IQuestionnaireRepository
    {
        Task<int> CreateQuestionnaire(Questionnaire questionnaire);
        Task DeleteQuestionnaire(int Id);
        Task<DetailsQuestionnaireDTO> GetDetailsQuestionnaireDTO(int id);
        Task<IndexPageDTO> GetIndexPageDTO();
    }
}
