using PastebookModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PastebookService
{
    public class AccountDataAccess : BaseDataAccess
    {

        public int CreateUserAccount(User user)
        {
            int result = 0;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    context.PB_USER.Add(UserMapper.ToPB_USER(user));
                    result = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }

        public User GetUserAccount(string email)
        {
            User user = new User();
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    user = UserMapper.ToUser(
                        context.PB_USER.Where(x => x.EMAIL == email)
                        .FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return user;
        }

        public User GetUserAccount(int ID)
        {
            User user = new User();
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    user = UserMapper.ToUser(
                        context.PB_USER.Where(x => x.ID == ID)
                        .FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return user;
        }

        public User GetUserAccountUsingUsername(string username)
        {
            User user = new User();
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    user = UserMapper.ToUser(
                        context.PB_USER.Where(x => x.USER_NAME == username)
                        .FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return user;
        }

        public List<User> SearchUsers(string name)
        {
            List<User> retVal = new List<User>();
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    var users = context.PB_USER.Where(x=>x.FIRST_NAME.Contains(name) || x.LAST_NAME.Contains(name));
                    foreach (var item in users)
                    {
                        retVal.Add(UserMapper.ToUser(item));
                    }
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return retVal;
        }

        public int UpdateUserAccount(User user)
        {
            int result = 0;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    context.Entry(UserMapper.ToPB_USER(user)).State = EntityState.Modified;
                    result = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }
        
        public bool EmailExists(string email)
        {
            bool result = false;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    result = context.PB_USER.Any(x => x.EMAIL == email);
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }

        public bool UserIDExists(int ID)
        {
            bool result = false;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    result = context.PB_USER.Any(x => x.ID == ID);
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }
    }
}