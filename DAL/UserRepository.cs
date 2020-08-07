using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using ViewModels;
namespace DAL
{
    interface IUserRepository
    {
        bool Add(User user);
        bool Update(User user);
        bool Delete(int id);
        User GetById(int id);
        IEnumerable<User> GetAll();
    }
    public class UserRepository : IUserRepository
    {

        WebAppDbContext db = new WebAppDbContext();
        public bool Add(User user)
        {
            tbl_User us = new tbl_User();
            us.UserId = user.UserId;
            us.UserName = user.UserName;
            us.Password = user.Password;
            us.Email = user.Email;
            us.Gender = user.Gender;
            us.IsInterestedInCSharp = user.IsInterestedInCSharp;
            us.IsInterestedInJava = user.IsInterestedInJava;
            us.IsInterestedInPython = user.IsInterestedInPython;
            us.CityId = user.CityId;
            us.DOB = user.DOB;
            db.tbl_User.Add(us);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            tbl_User user = db.tbl_User.Find(id);
            if(user == null)
            {
                return false;
            }
            else
            {
                db.tbl_User.Remove(user);
                db.SaveChanges();
                return true;
            }
        }

        public IEnumerable<User> GetAll()
        {
            List<User> list = new List<User>();
            foreach (var user in db.tbl_User)
            {
                User us= new User();
                us.UserId = user.UserId;
                us.UserName = user.UserName;
                us.Password = user.Password;
                us.Email = user.Email;
                us.Gender = user.Gender;
                us.IsInterestedInCSharp = (bool)user.IsInterestedInCSharp;
                us.IsInterestedInJava = (bool)user.IsInterestedInJava;
                us.IsInterestedInPython = (bool)user.IsInterestedInPython;
                us.CityId = (int)user.CityId;
                us.DOB = (DateTime)user.DOB;
                list.Add(us);
            }
            return list;
        }

        public User GetById(int id)
        {
            tbl_User user = db.tbl_User.Find(id);
            if(user == null)
            {
                return null;
            }
            else
            {
                User us = new User();
                us.UserId = user.UserId;
                us.UserName = user.UserName;
                us.Password = user.Password;
                us.Email = user.Email;
                us.Gender = user.Gender;
                us.IsInterestedInCSharp = (bool)user.IsInterestedInCSharp;
                us.IsInterestedInJava = (bool)user.IsInterestedInJava;
                us.IsInterestedInPython = (bool)user.IsInterestedInPython;
                us.CityId = (int)user.CityId;
                us.DOB = (DateTime)user.DOB;
                return us;
            }
        }

        public bool Update(User user)
        {
            tbl_User us = db.tbl_User.Find(user.UserId);
            us.UserName = user.UserName;
            us.Password = user.Password;
            us.Email = user.Email;
            us.Gender = user.Gender;
            us.IsInterestedInCSharp = (bool)user.IsInterestedInCSharp;
            us.IsInterestedInJava = (bool)user.IsInterestedInJava;
            us.IsInterestedInPython = (bool)user.IsInterestedInPython;
            us.CityId = (int)user.CityId;
            us.DOB = (DateTime)user.DOB;
            db.SaveChanges();
            return true;
        }        
    }
}
