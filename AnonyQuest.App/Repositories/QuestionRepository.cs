using AnonyQuest.App.Data;
using AnonyQuest.Shared.Entities;

namespace AnonyQuest.App.Repositories
{
    public class QuestionRepository : GenericRepository<Question>
    {

        public QuestionRepository(ApplicationDbContext context) : base(context)
        {
        }


    }

}
