using ForumaApplication.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace ForumApplication.Repository
{
    interface IAnswerRepository
    {
        void InsertAnswer(Answers a);
        void UpdateAnswer(Answers a);
        void DeleteAnswer(int a);
        void UpdateAnswerVotesCount(int aid, int uid, int value);
        List<Answers> GetAnswerByQuestionID(int qid);
        List<Answers> GetAnswerByAnswerID(int aid);
    }
    public class AnswersRepository : IAnswerRepository
    {
        private ForumAppDbContext _dbcontext;
        private QuestionsRepository _qr;
        private VotesRepository _vr;

        public AnswersRepository()
        {
            _dbcontext = new ForumAppDbContext();
            _qr = new QuestionsRepository();
            _vr = new VotesRepository();
        }
        public void InsertAnswer(Answers a)
        {
            _dbcontext.Answers.Add(a);
            _dbcontext.SaveChanges();
            _qr.UpdateQuestionAnswerCount(a.QuestionID, 1);

        }
        public void UpdateAnswer(Answers a)
        {
            Answers ans = _dbcontext.Answers.Where(x=>x.AnswerID== a.AnswerID).FirstOrDefault();    
            if(ans != null)
            {
                ans.AnswerText = a.AnswerText;  
                ans.AnswerDateAndTime = a.AnswerDateAndTime;
                //ans.UserID = a.UserID;  
                //ans.QuestionID = a.QuestionID;  
                //ans.VotesCount = a.VotesCount;
                _dbcontext.SaveChanges();
            }
        }
        public void DeleteAnswer(int a)
        {
            _dbcontext.Answers.Remove(_dbcontext.Answers.Find(a));
            _dbcontext.SaveChanges();   
        }
        public void UpdateAnswerVotesCount(int aid, int uid, int value)
        {
            Answers ans = _dbcontext.Answers.Where(x=>x.AnswerID == aid && x.UserID == uid).FirstOrDefault();   
            if(ans != null)
            {
                ans.VotesCount += value;
                _dbcontext.SaveChanges();
                _qr.UpdateQuestionVoteCount(ans.QuestionID, value);
            }
        }
        public List<Answers> GetAnswerByQuestionID(int qid)
        {
            return _dbcontext.Answers.Where(x=>x.QuestionID == qid).ToList();
        }
        public List<Answers> GetAnswerByAnswerID(int aid)
        {
            return _dbcontext.Answers.Where(x=>x.AnswerID==aid).ToList();   
        }

    }
}
