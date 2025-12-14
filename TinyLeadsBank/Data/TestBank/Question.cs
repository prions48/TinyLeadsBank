using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyLeadsBank.Data.TestBank
{
    public class Question : ICategoried
    {
        [Key] public Guid ID { get; set; } = Guid.NewGuid();
        public Guid TopicID { get; set; }
        public string QuestionText { get; set; } = "";
        public Guid? ImageID { get; set; }
        public int? Difficulty { get; set; }
        public string? Categories { get; set; }
        public int OrderNumber { get; set; }
        public List<string> Cats => Categories == null ? [] : Categories.Split("|").ToList();
        [NotMapped] public List<QuestionOption> Options { get; set; } = [];
        [NotMapped] public bool View { get; set; } = false;
    }
}