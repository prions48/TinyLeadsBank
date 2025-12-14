using System.ComponentModel.DataAnnotations;

namespace TinyLeadsBank.Data.TestBank
{
    public class ExamData
    {
        [Key] public Guid ID { get; set; } = Guid.NewGuid();
        public Guid ExamID { get; set; }
        public string Data { get; set; } = "";
        public bool KeyMode { get; set; }
    }
}