using Microsoft.EntityFrameworkCore;

namespace TinyLeadsBank.Data.TestBank
{
    public class TestBankContext : DbContext
    {
        public TestBankContext(DbContextOptions<TestBankContext> options) : base(options)
        {
            
        }
        public DbSet<Topic> TestBankTopics { get; set; }
        public DbSet<Exam> TestBankExams { get; set; }
        public DbSet<Image> TestBankImages { get; set; }
        public DbSet<ExamQuestion> TestBankExamQuestions { get; set; }
        public DbSet<Question> TestBankQuestions { get; set; }
        public DbSet<QuestionOption> TestBankQuestionOptions { get; set; }
    }
}