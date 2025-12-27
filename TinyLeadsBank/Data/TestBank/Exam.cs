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
        public bool Closed { get; set; } = false;
        [NotMapped] public List<ExamQuestion> ExamQuestions { get; set; } = [];
        public string GenerateHTML(List<Image> images, bool keymode)
        {
            string preview = $"<h3>{this.TestName}</h3><ol type=\"1\">";
            foreach (ExamQuestion question in ExamQuestions.OrderBy(e => e.OrderNumber))
            {
                preview += "<li>" + (question.Question.ImageID == null ? "" : $"<img src=\"data:image/png;base64, {images.FirstOrDefault(e => e.ID == question.Question.ImageID)?.ImageContent}\" /><br />") + question.Question.QuestionText + "<ol type=\"A\">";
                foreach (QuestionOption option in question.Question.Options)
                {
                    if (keymode && option.CorrectAnswer)
                        preview += "<b>";
                    preview += "<li>" + option.AnswerText + "</li>";
                    if (keymode && option.CorrectAnswer)
                        preview += "</b>";
                }
                preview += "</ol></li>";
            }
            preview += "</ol>";
            return preview;
        }
    }
}