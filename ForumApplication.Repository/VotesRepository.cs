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
    public class VotesRepository : IVotesRepository
    {
        private ForumAppDbContext _dbContext;
        public VotesRepository()
        {
            _dbContext = new ForumAppDbContext();   
        }
        public void UpdateVote(int aid, int uid, int value)
        {
            int updatevalue;
          if(value > 0)
            {
                updatevalue = 1;
            }
          else if(value < 0)
            {
                updatevalue = -1;
            }
            else
            {
                updatevalue = 0;
            }
            var votes = _dbContext.Votes.Where(x => x.AnswerID == aid && x.UserID == uid).FirstOrDefault();
            if(votes != null)
            {
                votes.VoteValues = updatevalue;
            }
            else
            {
                Votes vote = new Votes()
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
