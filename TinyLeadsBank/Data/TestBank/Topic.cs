using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyLeadsBank.Data.TestBank
{
    public class Topic : ICategoried
    {
        [Key] public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string TopicName { get; set; } = "";
        public string? Categories { get; set; }
        [NotMapped] public List<Question> Questions { get; set; } = [];
    }
}