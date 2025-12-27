using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyLeadsBank.Data.TestBank
{
    public class Exam
    {
        [Key] public Guid ID { get; set; } = Guid.NewGuid();
        public Guid UserID { get; set; }
        public string TestName { get; set; } = "";
        public DateTime CreatedTimeStamp { get; set; } = DateTime.Now;
        [NotMapped] public List<ExamQuestion> ExamQuestions { get; set; } = [];
    }
}