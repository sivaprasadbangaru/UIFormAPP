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
        public DbSet<Users> Users { get; set; }
        public DbSet<Categories> Category { get; set; }
        public DbSet<Questions> Questions { get; set; } 
        public DbSet<Answers> Answers { get; set; } 
        public DbSet<Votes> Votes { get; set; } 

    }
}
