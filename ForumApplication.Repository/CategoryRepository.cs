using ForumaApplication.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace ForumApplication.Repository
{
    interface ICategoryRepository
    {
        void InsertCategory(Categories c);
        void UpdateCategory(Categories c);  
        void DeleteCategory(int cid);  
        List<Categories> GetCategories();
        Categories GetCategoryByCategoryID(int categoryid);
    }
    public class CategoryRepository : ICategoryRepository   
    {
        private ForumAppDbContext _dbcontext;
        public CategoryRepository()
        {
            _dbcontext = new ForumAppDbContext();
        }
        public void InsertCategory(Categories c) 
        {
            Categories category = _dbcontext.Category.Add(c);
            _dbcontext.SaveChanges();
        }  
        public void UpdateCategory(Categories c)
        {
         Categories category =    _dbcontext.Category.Where(x=>x.CategoryID== c.CategoryID).FirstOrDefault();
           if(category != null)
            {
                category.CategoryName = c.CategoryName;
                _dbcontext.SaveChanges();
            }
           
        }
        public void DeleteCategory(int cid)
        {
            _dbcontext.Category.Remove(_dbcontext.Category.Find(cid));
            _dbcontext.SaveChanges();
        }

        public List<Categories> GetCategories()
        {
           return  _dbcontext.Category.ToList();
        }
        public Categories GetCategoryByCategoryID(int categoryid)
        {
            //Categories cat = _dbcontext.Category.Where(x=>x.CategoryID== categoryid).FirstOrDefault();
            //return cat; 
           return _dbcontext.Category.Find(categoryid);
        }
    }
}
