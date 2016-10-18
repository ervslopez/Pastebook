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

        public int CreateUserAccount(UserRequest request)
        {
            int result = 0;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    context.PB_USER.Add(UserMapper.ToPB_USER(request.user));
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
        
        public int UpdateUserAccount(UserRequest request)
        {
            int result = 0;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    context.Entry(UserMapper.ToPB_USER(request.user)).State = EntityState.Modified;
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