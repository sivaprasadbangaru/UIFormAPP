using ForumaApplication.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Repository
{
    public interface IVotesRepository
    {
        void UpdateVote(int aid, int uid, int value);
    }
    public class VotesRepository
    {
        private ForumAppDbContext _dbContext;
        public VotesRepository()
        {
            _dbContext = new ForumAppDbContext();   
        }
        public void UpdateVote(int aid, int uid, int value)
        {
            int updateValue;
            if(value > 0)
            {
                updateValue = 1;
            }
            else if(value< 0) { 
            
            updateValue = -1;   
            }
            else
            {
                updateValue = 0;
            }
            var vote = _dbContext.Votes.Where(x => x.AnswerID == aid && x.UserID == uid).FirstOrDefault();
            if(vote != null)
            {
                vote.VoteValues = updateValue;
            }
            else
            {
                Votes votes = new Votes()
                {
                    UserID = uid,
                    AnswerID = aid,
                    VoteValues = value

                };
            _dbContext.Votes.Add(vote);
            _dbContext.SaveChanges();
            }
        }
    }
}
