using Ps12922_HoManhDung_ASM.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2.Models;
using Test2.Models.ViewModels;

namespace Test2.Services
{
    public interface IUserSvc
    {
        List<User> GetUserAll();
        User GetUser(int id);
        int AddUser(User user);
        int EditUser(int id, User user);
        User Login(ViewLogin viewLogin);
    }
    public class UserSvc : IUserSvc
    {
        protected DataContext _context;
        protected IMahoaHelper _mahoaHelper;
        public UserSvc(DataContext context, IMahoaHelper mahoaHelper)
        {
            _context = context;
            _mahoaHelper = mahoaHelper;
        }

        public List<User> GetUserAll()
        {
            List<User> list = new List<User>();
            list = _context.Users.ToList();
            return list;
        }

        public User GetUser(int id)
        {
            User user = null;
            user = _context.Users.Find(id); 
            return user;
        }

        public int AddUser(User user)
        {
            int ret = 0;
            try
            {
                user.UserPassword = _mahoaHelper.Mahoa(user.UserPassword);
                _context.Add(user);
                _context.SaveChanges();
                ret = user.UserID;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public int EditUser(int id, User user)
        {
            int ret = 0;
            try
            {
                User _user = null;
                _user = _context.Users.Find(id);
                _user.UserFullName = user.UserFullName;
                _user.UserEmail = user.UserEmail;
                _user.UserBirthday = user.UserBirthday;
                _user.UserPhone = user.UserPhone;
                if (user.UserPassword != null)
                {
                    user.UserPassword = _mahoaHelper.Mahoa(user.UserPassword);
                    _user.UserPassword = user.UserPassword;
                }
                _context.Update(_user);
                _context.SaveChanges();
                ret = user.UserID;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
        public User Login(ViewLogin viewLogin)
        {
            var u = _context.Users.Where(
                p => p.UserFullName.Equals(viewLogin.UserName)
                && p.UserPassword.Equals(_mahoaHelper.Mahoa(viewLogin.Password))
                ).FirstOrDefault();
            return u;
        }
    }
}
