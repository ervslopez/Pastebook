
using PastebookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookService
{
    public class AccountManager
    {
        PasswordManager passwordManager = new PasswordManager();
        AccountDataAccess dataAccess = new AccountDataAccess();

        public CreateUserResponse CreateUserAccount(UserRequest request)
        {
            CreateUserResponse resp = new CreateUserResponse();
            try
            {
                if (!UsernameExists(request.user.USER_NAME))
                {
                    resp.UserNameExists = false;
                    string salt = null;
                    request.user.PASSWORD = passwordManager.GeneratePasswordHash(request.user.PASSWORD, out salt);
                    request.user.SALT = salt;
                    resp.Status = dataAccess.CreateUserAccount(request) > 0? true: false;
                }
                else
                {
                    resp.UserNameExists = true;
                }
            }
            catch (Exception e)
            {
               // resp.errorList.Add(e);
            }
            return resp;
        }

        public LoginResponse LoginUserAccount(LoginRequest request)
        {
            LoginResponse resp = new LoginResponse();
            try
            {
                if (UsernameExists(request.username))
                {
                    resp.UserNameExists = true;
                    resp.user = dataAccess.GetUserAccount(request);
                    if (!passwordManager.PasswordMatch(request.password, resp.user.SALT, resp.user.PASSWORD))
                    {
                        resp.PasswordMatched = false;
                        resp.user = new User();
                    }else
                    {
                        resp.Status = true;
                        resp.PasswordMatched = true;
                    }
                }
                else
                {
                    resp.UserNameExists = false;
                }
            }
            catch (Exception e)
            {
                //resp.errorList.Add(e);
            }
            return resp;
        }

        public StatusResponse UpdateUserAccount(UserRequest request)
        {
            StatusResponse resp = new StatusResponse();
            try
            {
                resp.Status = dataAccess.UpdateUserAccount(request) > 0 ? true : false;
            }
            catch (Exception e)
            {
                //resp.errorList.Add(e);
            }
            return resp;
        }

        public StatusResponse UpdatePasswordOrEmail(EditPasswordOrEmailRequest request)
        {
            StatusResponse resp = new StatusResponse();
            try
            {
                LoginResponse loginResp = LoginUserAccount(new LoginRequest() {
                    username = request.user.USER_NAME,
                    password = request.OldPassword
                });

                if (loginResp.PasswordMatched)
                {
                    string salt = null;
                    request.user.PASSWORD = passwordManager.GeneratePasswordHash(request.user.PASSWORD, out salt);
                    request.user.SALT = salt;
                    resp.Status = dataAccess.UpdateUserAccount(request) > 0 ? true : false;
                }else
                {
                    resp.Status = false;
                }
            }
            catch (Exception e)
            {
                //resp.errorList.Add(e);
            }
            return resp;
        }

        public bool UsernameExists(string username)
        {
            return dataAccess.UsernameExists(username);
        }
        
        public bool UserIDExists(int ID)
        {
            return dataAccess.UserIDExists(ID);
        }

    }
}