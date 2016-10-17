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
                using (var context = new DB_PASTEBOOKEntities1())
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

        public User GetUserAccount(LoginRequest request)
        {
            User user = new User();
            try
            {
                using (var context = new DB_PASTEBOOKEntities1())
                {
                    user = UserMapper.ToUser(
                        context.PB_USER.Where(x => x.USER_NAME == request.username)
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
                using (var context = new DB_PASTEBOOKEntities1())
                {
                    context.Entry(UserMapper.ToPB_USER(request.user)).State = EntityState.Modified;
                    //PB_USER userRequest = UserMapper.toPB_USER(GetUserAccount(new LoginRequest() {
                    //    username = request.user.USER_NAME
                    //}));

                    //context.PB_USER.Attach(userRequest);
                    //userRequest.PROFILE_PIC = request.user.PROFILE_PIC;
                    //userRequest.ABOUT_ME = request.user.ABOUT_ME;
                    //userRequest.PASSWORD = request.user.PASSWORD;
                    //userRequest.SALT = request.user.SALT;
                    //userRequest.EMAIL = request.user.EMAIL;
                    result = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }
        
        public bool UsernameExists(string username)
        {
            bool result = false;
            try
            {
                using (var context = new DB_PASTEBOOKEntities1())
                {
                    result = context.PB_USER.Any(x => x.USER_NAME == username);
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
                using (var context = new DB_PASTEBOOKEntities1())
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