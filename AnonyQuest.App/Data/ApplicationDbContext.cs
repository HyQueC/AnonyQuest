using AnonyQuest.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnonyQuest.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .Property<int>("UserId")
                .IsRequired();

            modelBuilder.Entity<Questionnaire>()
                .Property<string>("AuthorEmail")
                .IsRequired();

            modelBuilder.Entity<ReceiverQuestionnaire>()
                .HasKey("ReceiverEmail", "QuestionnaireId");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Answer> Answer { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Questionnaire> Questionnaire { get; set; }
        public DbSet<ReceiverQuestionnaire> ReceiverQuestionnaire { get; set; }
    }
}
