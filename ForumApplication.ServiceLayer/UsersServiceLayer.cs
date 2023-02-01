using AutoMapper;
using ForumaApplication.DataModel;
using ForumApplication.Repository;
using ForumApplication.ViewModel.LoginAndRegisterViewModel;
using ForumApplication.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ServiceLayer
{
    public interface IserviceLayer
    {
        int InsertUser(RegisterViewModel rvm);
        void UpdateUserDetails(EditUserDetailsViewModel evm);
        void UpdateUserPassword(EditUserDetailsViewModel evm);
        void DeleteUser(int uid);
        List<UsersViewModel> GetUsers();
        UsersViewModel GetUserByEmailAndPassword(string email , string password);
        UsersViewModel GetUserByEmail(string email);
    }
    public class UsersServiceLayer : IserviceLayer
    {
        UserRepository _ur;
        public UsersServiceLayer()
        {
            _ur = new UserRepository();
        }
        //private void CreateUserMapper()
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<UsersViewModel, Users>();
        //        cfg.IgnoreUnmapped();
        //    });
        //    IMapper mapper = config.CreateMapper();
        //    Users u = mapper.Map< Users>();
        //}
        public void DeleteUser(int uid)
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<UsersViewModel, Users>();
            //    cfg.IgnoreUnmapped();
            //});
            //IMapper mapper = config.CreateMapper();
            //Users u = mapper.Map<Users>(uid);

            _ur.DeleteUser(uid);
        }

        public UsersViewModel GetUserByEmail(string email)
        {
           Users u = _ur.GetUserEmail(email);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Users,UsersViewModel>();
                cfg.IgnoreUnmapped();
            });
                 var mapper = config.CreateMapper();
           UsersViewModel uvm =  mapper.Map<Users, UsersViewModel>(u);
            return uvm;

            
        }

        public UsersViewModel GetUserByEmailAndPassword(string email, string password)
        {
            Users u = _ur.GetUserEmailAndPassword(email, password);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsersViewModel, Users>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            UsersViewModel uvm =  mapper.Map<Users, UsersViewModel>(u);
            return uvm;

        }

        public List<UsersViewModel> GetUsers()
        {
            List<Users> users = new List<Users>();  
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Users,UsersViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
           List<UsersViewModel> u = mapper.Map<List<Users>,List<UsersViewModel>>(users);
           _ur.GetUser();
            return u;
        }

        public int InsertUser(RegisterViewModel rvm)
        {
            var config = new MapperConfiguration(cfg =>
            {cfg.CreateMap<RegisterViewModel, Users>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Users u = mapper.Map<RegisterViewModel, Users>(rvm);
            _ur.InsertUser(u);
            return _ur.GetLatestUserId();

        }

        public void UpdateUserDetails(EditUserDetailsViewModel evm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EditUserDetailsViewModel, Users>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Users u = mapper.Map<EditUserDetailsViewModel, Users>(evm);
            _ur.UpdateUser(u);

        }

        public void UpdateUserPassword(EditUserDetailsViewModel evm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EditUserDetailsViewModel, Users>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Users u = mapper.Map<EditUserDetailsViewModel, Users>(evm);
            _ur.UpdatePassword(u);
        }
    }
}
