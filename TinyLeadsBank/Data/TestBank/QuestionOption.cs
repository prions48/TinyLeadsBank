using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyLeadsBank.Data.TestBank
{
    public class QuestionOption
    {
        [Key] public Guid ID { get; set; } = Guid.NewGuid();
        public Guid QuestionID { get; set; }
        public string AnswerText { get; set; } = "";
        public bool CorrectAnswer { get; set; }
        public int OrderNumber { get; set; }
        [NotMapped] public bool CreateNew { get; set; } = false;
        [NotMapped] public bool Delete { get; set; } = false;
    }
}