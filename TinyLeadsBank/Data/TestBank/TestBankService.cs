using Microsoft.EntityFrameworkCore;

namespace TinyLeadsBank.Data.TestBank
{
    public class TestBankService
    {
        private readonly TestBankContext _context;
        public TestBankService(TestBankContext context)
        {
            _context = context;
        }
        public Topic? GetTopicByID(Guid topicid)
        {
            return _context.TestBankTopics.FirstOrDefault(e => e.ID == topicid);//not loaded with questions
        }
        public List<Topic> GetTopicsByUserID(Guid userid)
        {
            List<Topic> topics = _context.TestBankTopics.Where(e => e.UserID == userid).ToList();
            foreach (Topic topic in topics)
            {
                topic.Questions = GetQuestionsByTopic(topic.ID);
            }
            return topics;
        }
        public List<Image> GetImagesByTopic(Guid topicid)
        {
            return _context.TestBankImages.Where(e => e.TopicID == topicid).ToList();
        }
        public List<Image> GetImagesByUserID(Guid userid)
        {
            //YES I know EF can do joins.  I'll add it later ok?  I'm tired and I know this works.
            return _context.TestBankImages.FromSqlRaw($"SELECT [TestBankImages].* FROM TestBankImages JOIN TestBankTopics ON TestBankTopics.ID=TestBankImages.TopicID WHERE TestBankTopics.UserID='{userid}'").ToList();
        }
        public void CreateImage(Image image)
        {
            _context.TestBankImages.Add(image);
            _context.SaveChanges();
        }
        public Image? GetImageByID(Guid imageid)
        {
            return _context.TestBankImages.FirstOrDefault(e => e.ID == imageid);
        }
        public void CreateTopic(Topic topic)
        {
            _context.TestBankTopics.Add(topic);
            _context.SaveChanges();
        }
        public void UpdateTopic(Topic topic)
        {
            _context.TestBankTopics.Update(topic);
            _context.SaveChanges();
        }
        public void DeleteTopic(Topic topic)
        {
            _context.TestBankTopics.Remove(topic);
            _context.SaveChanges();
        }
        #region Questions
        private List<Question> GetQuestionsByTopic(Guid topicid)
        {
            List<Question> questions = _context.TestBankQuestions.Where(e => e.TopicID == topicid).ToList();
            foreach (Question question in questions)
            {
                question.Options = _context.TestBankQuestionOptions.Where(e => e.QuestionID == question.ID).ToList();
            }
            return questions;
        }
        public void CreateQuestion(Question question)
        {
            _context.TestBankQuestions.Add(question);
            foreach (QuestionOption option in question.Options)
                _context.TestBankQuestionOptions.Add(option);
            _context.SaveChanges();
        }
        public void UpdateQuestion(Question question)
        {
            _context.TestBankQuestions.Update(question);
            foreach (QuestionOption option in question.Options)
            {
                if (option.CreateNew)
                    _context.TestBankQuestionOptions.Add(option);
                else if (option.Delete)
                    _context.TestBankQuestionOptions.Remove(option);
                else
                    _context.TestBankQuestionOptions.Update(option);
            }
            _context.SaveChanges();
        }
        public void DeleteQuestion(Question question)
        {
            _context.TestBankQuestions.Remove(question);
            foreach (QuestionOption option in question.Options)
                _context.TestBankQuestionOptions.Remove(option);
            _context.SaveChanges();
        }
        #endregion

        #region Exams
        public List<Exam> GetExamsByUserID(Guid userid)
        {
            List<Exam> exams = _context.TestBankExams.Where(e => e.UserID == userid).ToList();
            List<Question> questions = _context.TestBankQuestions.FromSqlRaw($"SELECT [TestBankQuestions].* FROM TestBankQuestions JOIN TestBankTopics ON TestBankTopics.ID=TestBankQuestions.TopicID WHERE TestBankTopics.UserID='{userid}'").ToList();
            foreach (Exam exam in exams)
            {
                exam.ExamQuestions = _context.TestBankExamQuestions.Where(e => e.ExamID == exam.ID).ToList();
                foreach (ExamQuestion question in exam.ExamQuestions)
                {
                    question.Question = questions.FirstOrDefault(e => e.ID == question.QuestionID)!;
                }
            }
            return exams;
        }
        public void CreateExam(Exam exam)
        {
            _context.TestBankExams.Add(exam);
            foreach (ExamQuestion question in exam.ExamQuestions)
            {
                _context.TestBankExamQuestions.Add(question);
            }
            _context.SaveChanges();
        }
        public void UpdateExam(Exam exam)
        {
            _context.TestBankExams.Update(exam);
            foreach (ExamQuestion question in exam.ExamQuestions)
            {
                if (question.Delete && !question.CreateNew)
                    _context.TestBankExamQuestions.Remove(question);
                else if (question.CreateNew)
                    _context.TestBankExamQuestions.Add(question);
                else
                    _context.TestBankExamQuestions.Update(question);
            }
        }
        #endregion
    }
}