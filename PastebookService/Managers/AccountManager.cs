
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
                if (!EmailExists(request.user.EMAIL))
                {
                    resp.emailExists = false;
                    string salt = null;
                    request.user.PASSWORD = passwordManager.GeneratePasswordHash(request.user.PASSWORD, out salt);
                    request.user.SALT = salt;
                    request.user.DATE_CREATED = DateTime.Now;
                    resp.Status = dataAccess.CreateUserAccount(request.user) > 0 ? true : false;
                }
                else
                {
                    resp.emailExists = true;
                }
            }
            catch (Exception e)
            {
                resp.errorList.Add(e.ToString());
            }
            return resp;
        }

        public LoginResponse LoginUserAccount(LoginRequest request)
        {
            LoginResponse resp = new LoginResponse();
            try
            {
                if (EmailExists(request.email))
                {
                    resp.emailExists = true;
                    resp.user = GetUser(request.email);
                    if (PasswordMatch(request.password, resp.user.SALT, resp.user.PASSWORD))
                    {
                        resp.passwordMatched = true;
                        resp.Status = true;
                        resp.user.PASSWORD = request.password;
                    }
                    else
                    {
                        resp.passwordMatched = false;
                        resp.user = new User();
                    }
                }
                else
                {
                    resp.emailExists = false;
                }
            }
            catch (Exception e)
            {
                resp.errorList.Add(e.ToString());
            }
            return resp;
        }

        public EditUserResponse UpdateUserAccount(UserRequest request)
        {
            EditUserResponse resp = new EditUserResponse();
            try
            {
                if (EmailExists(request.user.EMAIL))
                {
                    resp.emailExists = true;
                    resp.user = GetUser(request.user.EMAIL);
                    request.user.ID = resp.user.ID;
                    resp.passwordMatched = true;
                    request.user.ID = resp.user.ID;
                    request.user.PASSWORD = resp.user.PASSWORD;
                    request.user.SALT = resp.user.SALT;
                    if (resp.Status = dataAccess.UpdateUserAccount(request.user) > 0)
                    {
                        resp.user = GetUser(request.user.EMAIL);
                    }
                }
                else
                {
                    resp.passwordMatched = false;
                    resp.emailExists = false;
                    resp.user = new User();
                }
            }
            catch (Exception e)
            {
                resp.errorList.Add(e.ToString());
            }
            return resp;
        }

        public EditUserResponse UpdateUserPassword(UserRequest request)
        {
            EditUserResponse resp = new EditUserResponse();
            try
            {
                if (EmailExists(request.user.EMAIL))
                {
                    resp.emailExists = true;
                    resp.user = GetUser(request.user.EMAIL);
                    resp.passwordMatched = true;
                    request.user.ID = resp.user.ID;
                    if(request.user.PASSWORD.Length>0)
                    {
                        String salt;
                        request.user.PASSWORD = passwordManager.GeneratePasswordHash(request.user.PASSWORD, out salt);
                        request.user.SALT = salt;
                    }
                    else
                    {
                        request.user.PASSWORD = resp.user.PASSWORD;
                        request.user.SALT = resp.user.SALT;
                    }

                    if (resp.Status = dataAccess.UpdateUserAccount(request.user) > 0)
                    {
                        resp.user = GetUser(request.user.EMAIL);
                    }
                }
                else
                {
                    resp.passwordMatched = false;
                    resp.emailExists = false;
                    
                    resp.user = GetUserUsingUN(request.user.USER_NAME);
                    request.user.ID = resp.user.ID;
                    if (request.user.PASSWORD.Length > 0)
                    {
                        String salt;
                        request.user.PASSWORD = passwordManager.GeneratePasswordHash(request.user.PASSWORD, out salt);
                        request.user.SALT = salt;
                    }
                    else
                    {
                        request.user.PASSWORD = resp.user.PASSWORD;
                        request.user.SALT = resp.user.SALT;
                    }

                    if (resp.Status = dataAccess.UpdateUserAccount(request.user) > 0)
                    {
                        resp.user = GetUser(request.user.EMAIL);
                    }
                }
            }
            catch (Exception e)
            {
                resp.errorList.Add(e.ToString());
            }
            return resp;
        }

        public EditUserResponse UpdatePasswordOrEmail(EditPasswordOrEmailRequest request)
        {
            EditUserResponse resp = new EditUserResponse();
            try
            {
                if (EmailExists(request.OldEmail))
                {
                    resp.emailExists = true;
                    resp.user = GetUser(request.OldEmail);
                    if (PasswordMatch(request.OldPassword, resp.user.SALT, resp.user.PASSWORD))
                    {
                        resp.passwordMatched = true;
                        string salt = null;
                        request.user.PASSWORD = passwordManager.GeneratePasswordHash(request.user.PASSWORD, out salt);
                        request.user.SALT = salt;
                        request.user.ID = resp.user.ID;
                        if (resp.Status = dataAccess.UpdateUserAccount(request.user) > 0)
                        {
                            resp.user = GetUser(request.user.EMAIL);
                        }
                    }
                    else
                    {
                        resp.passwordMatched = false;
                        resp.user = new User();
                    }
                }
                else
                {
                    resp.emailExists = false;
                }
            }
            catch (Exception e)
            {
                resp.errorList.Add(e.ToString());
            }
            return resp;
        }

        public GetAccountProfileResponse GetAccountProfile(GetAccountProfileRequest request)
        {
            GetAccountProfileResponse resp = new GetAccountProfileResponse();
            try
            {
                if (request.accountID > 0)
                {
                    resp.user = dataAccess.GetUserAccount(request.accountID);
                }
                else if (request.email.ToString().Length > 0)
                {
                    resp.user = dataAccess.GetUserAccount(request.email);
                }
                else
                {
                    resp.user = dataAccess.GetUserAccountUsingUsername(request.username);
                }
            }
            catch (Exception e)
            {
                resp.errorList.Add(e.ToString());
            }
            return resp;
        }

        public User GetUser(string email)
        {
            return dataAccess.GetUserAccount(email);
        }

        public User GetUserUsingUN(string username)
        {
            return dataAccess.GetUserAccountUsingUsername(username);
        }

        public List<User> SearchUsers(string name)
        {
            return dataAccess.SearchUsers(name);
        }

        public bool EmailExists(string email)
        {
            return dataAccess.EmailExists(email);
        }

        public bool UserIDExists(int ID)
        {
            return dataAccess.UserIDExists(ID);
        }

        public bool PasswordMatch(string password, string salt, string hash)
        {
            return passwordManager.PasswordMatch(password, salt, hash);
        }

        public bool ConfirmOldPassword(int userID, string oldPassword)
        {
            User user = GetAccountProfile(new GetAccountProfileRequest()
            {
                accountID = userID
            }).user;

            return PasswordMatch(oldPassword, user.SALT, user.PASSWORD);
        }

        public GetCountriesResponse GetCountries()
        {
            UtilityDataAccess util = new UtilityDataAccess();
            GetCountriesResponse resp = new GetCountriesResponse();
            resp.CountryList = CountryMapper.toCountryDictionary(util.GetCountries());
            return resp;
        }
    }
}