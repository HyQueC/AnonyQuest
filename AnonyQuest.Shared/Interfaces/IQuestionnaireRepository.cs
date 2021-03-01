using AnonyQuest.Shared.DTOs;
using AnonyQuest.Shared.Entities;
using System.Threading.Tasks;

namespace AnonyQuest.Shared.Interfaces
{
    public interface IQuestionnaireRepository : IRepository<Questionnaire>
    {
        Task<IndexPageDTO> GetIndexPageDTO(string userEmail);
        Task<Questionnaire> GetDetailsByUserAsync(int id, string userEmail);
    }
}
