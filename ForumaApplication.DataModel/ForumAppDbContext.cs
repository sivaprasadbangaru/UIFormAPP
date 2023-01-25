using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ForumaApplication.DataModel
{
    public class ForumAppDbContext  : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Question> Questions { get; set; } 
        public DbSet<Answer> Answers { get; set; } 
        public DbSet<Vote> Votes { get; set; } 
    }
}
