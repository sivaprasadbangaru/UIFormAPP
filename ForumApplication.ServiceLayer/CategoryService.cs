using AutoMapper;
using ForumaApplication.DataModel;
using ForumApplication.Repository;
using ForumApplication.ViewModel.CategoriesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ServiceLayer
{
    public interface ICategoryService
    {
        void InsertCategory(CategoryViewModel cvm);
        void UpdateCategory(CategoryViewModel cvm);
        void DeleteCategory(int uid);
        List<CategoryViewModel> GetAllCategories();
        CategoryViewModel GetCategoryByCategoryID(int cid);
    }
    public class CategoryService : ICategoryService
    {
        CategoryRepository _cr;
        public CategoryService()
        {
            _cr = new CategoryRepository();
        }
        public void DeleteCategory(int uid)
        {
            _cr.DeleteCategory(uid);
        }

        public List<CategoryViewModel> GetAllCategories()
        {
            List<Categories> c = new List<Categories>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryViewModel, Categories>();
                cfg.IgnoreUnmapped();
            });
            var mapper = config.CreateMapper();
          List<CategoryViewModel> cat =  mapper.Map<List< Categories>, List<CategoryViewModel>>(c);
            _cr.GetCategories();
            return cat;


        }

        public CategoryViewModel GetCategoryByCategoryID(int cid)
        {
            Categories c = _cr.GetCategoryByCategoryID(cid);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryViewModel, Categories>();
                cfg.IgnoreUnmapped();
            });
            var mapper = config.CreateMapper();
           CategoryViewModel cvm = mapper.Map<Categories,CategoryViewModel>(c);
            _cr.GetCategories();
            return cvm;


        }

        public void InsertCategory(CategoryViewModel cvm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryViewModel, Categories>();
                cfg.IgnoreUnmapped();
            });
            var mapper = config.CreateMapper();
           Categories c = mapper.Map<CategoryViewModel, Categories>(cvm);
            _cr.InsertCategory(c);

        }

        public void UpdateCategory(CategoryViewModel cvm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryViewModel, Categories>();
                cfg.IgnoreUnmapped();
            });
            var mapper = config.CreateMapper();
            Categories c = mapper.Map<CategoryViewModel, Categories>(cvm);
            _cr.UpdateCategory(c); 
        }
    }
}
