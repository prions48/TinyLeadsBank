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
        public List<Topic> GetTopicsByUserID(Guid userid)
        {
            List<Topic> topics = _context.TestBankTopics.Where(e => e.UserID == userid).ToList();
            foreach (Topic topic in topics)
            {
                topic.Questions = GetQuestionsByTopic(topic.ID);
            }
            return topics;
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