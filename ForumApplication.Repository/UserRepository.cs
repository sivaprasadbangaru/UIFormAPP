using ForumaApplication.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ForumApplication.Repository
{
    public interface IUserRepository
    {
        void InsertUser(Users u);
        void UpdateUser(Users u);
        void UpdatePassword(Users u);
        void DeleteUser(int userid);
        List<Users> GetUser();
        Users GetUserEmailAndPassword(string email, string password);
        Users GetUserEmail(string email);
        int GetLatestUserId();
    }
    public class UserRepository : IUserRepository   
    {
        private ForumAppDbContext _dbcontext ;
        public UserRepository()
        {
            _dbcontext = new ForumAppDbContext();
        }
        public void InsertUser(Users u) 
        {
            _dbcontext.Users.Add(u);
            _dbcontext.SaveChanges();
        }
        public void UpdateUser(Users u) 
        {
            try
            {
                if (u != null && u.UserID > 0)
                {
                    Users user = _dbcontext.Users.Where(x => x.UserID == u.UserID).FirstOrDefault();
                    if (user != null)
                    {
                        user.name_ = u.name_;
                        user.mobile = u.mobile;
                        _dbcontext.SaveChanges();
                    }
                }
            } 
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public void UpdatePassword(Users u )
        {
            Users user = _dbcontext.Users.Find(u.UserID);
            user.PasswordHash = u.PasswordHash;
            _dbcontext.SaveChanges();
        }
        public void DeleteUser(int userid)
        {
            _dbcontext.Users.Remove(_dbcontext.Users.Find(userid));
            _dbcontext.SaveChanges();   
        }
        public List<Users> GetUser()
        {

            return _dbcontext.Users.ToList();
        }
        public Users GetUserEmailAndPassword(string email , string password)
        {
            Users users = _dbcontext.Users.Where(x => x.Email == email && x.PasswordHash == password).FirstOrDefault();
            return users;
        }
        public Users GetUserEmail(string email)
        {
            return _dbcontext.Users.Where(x=>x.Email == email).FirstOrDefault();    
        }

        public int GetLatestUserId()
        {
            Users u = _dbcontext.Users.OrderByDescending(x => x.UserID).Take(1).FirstOrDefault();

            return u.UserID;  
        }
    }
}
