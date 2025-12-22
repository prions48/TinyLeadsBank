using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyLeadsBank.Data.TestBank
{
    public class ExamQuestion
    {
        [Key] public Guid ID { get; set; } = Guid.NewGuid();
        public Guid ExamID { get; set; }
        public Guid QuestionID { get; set; }
        public int OrderNumber { get; set; }
        [NotMapped] public Question Question { get; set; }
        [NotMapped] public bool CreateNew { get; set; } = false;
        [NotMapped] public bool Delete { get; set; } = false;
    }
}