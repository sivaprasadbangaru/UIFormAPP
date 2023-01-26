using ForumaApplication.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace ForumApplication.Repository
{
    interface IQuestionRepository
    {
        void InsertQuestion(Questions q);
        void UpdateQuestionDetails(Questions q);
        void UpdateQuestionVoteCount(int qid, int value);
        void UpdateQuestionAnswerCount(int qid, int value);
        void UpdateQuestionViewsCount(int qid);
        void DeleteQuestion(int q);
        List<Questions> GetQuestions();
        Questions GetQuestionByQuestionID(int qid);

    }
    public class QuestionsRepository : IQuestionRepository
    {
        private ForumAppDbContext _dbcontext;
        public QuestionsRepository()
        {
            _dbcontext = new ForumAppDbContext();
        }
        public void InsertQuestion(Questions q)
        {
            _dbcontext.Questions.Add(q);
            _dbcontext.SaveChanges();
        }

        public void UpdateQuestionDetails(Questions q)
        {
            Questions question = _dbcontext.Questions.Where(x=>x.QuestionID== q.QuestionID).FirstOrDefault();
            if(question != null)
            {
                question.QuestionName = q.QuestionName;
                question.QuestionDateAndTime = q.QuestionDateAndTime;
                //question.UserID = q.UserID;
                question.CategoryID = q.CategoryID; 
               // question.ViewsCount = q.ViewsCount; 
               // question.AnsewrsCount = q.AnsewrsCount;
                //question.ViewsCount = q.ViewsCount;
                _dbcontext.SaveChanges();
            }
        }
        public void UpdateQuestionVoteCount(int qid, int value)
        {
           Questions question = _dbcontext.Questions.Where(x=>x.QuestionID == qid).FirstOrDefault();
            if (question != null)
            {
                question.VotesCount += value;
                _dbcontext.SaveChanges();
            }
        }
        public void UpdateQuestionAnswerCount(int qid, int value)
        {
            Questions qu = _dbcontext.Questions.Where(x=>x.QuestionID==qid).FirstOrDefault(); 
            if(qu != null)
            {
                qu.AnsewrsCount+= value;
                _dbcontext.SaveChanges();
            }

        }
        public void UpdateQuestionViewsCount(int qid)
        {
            Questions qu = _dbcontext.Questions.Where(x=>x.QuestionID == qid).FirstOrDefault(); 
            if(qu != null)
            { 
            qu.ViewsCount+= 1;
                _dbcontext.SaveChanges();
            }

        }
        public void DeleteQuestion(int q)
        {
            _dbcontext.Questions.Remove(_dbcontext.Questions.Find(q));
            _dbcontext.SaveChanges();
        }
        public List<Questions> GetQuestions()
        {

            return _dbcontext.Questions.ToList(); 
        }
        public Questions GetQuestionByQuestionID(int qid)
        {
            return _dbcontext.Questions.Where(x=>x.QuestionID == qid). FirstOrDefault();
        }
      
    }
}
