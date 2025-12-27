using System.ComponentModel.DataAnnotations;

namespace TinyLeadsBank.Data.TestBank
{
    public class Image
    {
        [Key] public Guid ID { get; set; } = Guid.NewGuid();
        public Guid TopicID { get; set; }
        public string ImageName { get; set; } = "";
        public string ImageContent { get; set; } = "";
        public DateTime CreatedTimeStamp { get; set; } = DateTime.Now;
    }
}