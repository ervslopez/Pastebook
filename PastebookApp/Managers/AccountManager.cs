using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PastebookApp.PastebookService;
using System.Web.Mvc;
using PastebookApp.Models;
using PastebookApp.Mapper;

namespace PastebookApp.Managers
{
    public class AccountManager
    {
        Service1Client service = new Service1Client();

        public SelectList GetCountries()
        {
            return new SelectList(service.GetCountries().CountryList, "Key", "Value");
        }

        public bool ValidateAccount(string email, string password, out UserModel model)
        {
            LoginResponse resp = service.LoginUserAccount(new LoginRequest()
            {
                email = email,
                password = password
            });

            if (resp.Status)
            {
                model = UserMapper.ToUserModel(resp.user);
            }else
            {
                model = null;
            }
            return resp.Status;
        }

        public bool RegisterAccount(ref UserModel model)
        {
            CreateUserResponse resp = service.CreateUserAccount(new UserRequest()
            {
                user = UserMapper.ToUser(model)
            });
            model = GetAccount(model.USER_NAME);
            return resp.Status;
        }

        public UserModel GetAccount(string username)
        {
            UserModel model = new UserModel();
            GetAccountProfileResponse resp = service.GetAccountProfile(new GetAccountProfileRequest()
            {
                username = username,
                accountID = 0,
                email = ""
            });
            model = UserMapper.ToUserModel(resp.user);
            return model;
        }

        public bool EditAccount(ref UserModel model)
        {
            EditUserResponse resp = service.EditUserProfile(new UserRequest()
            {
                user = UserMapper.ToUser(model)
            });
            return resp.Status;
        }

        public bool EditAccountPassword(ref UserModel model)
        {
            EditUserResponse resp = service.UpdateUserPassword(new UserRequest()
            {
                user = UserMapper.ToUser(model)
            });
            return resp.Status;
        }

        public List<User> SearchAccount(string name)
        {
            List<User> userList = service.SearchUsers(new SearchUsersRequest() {
                name = name
            }).userList.ToList();
            return userList;
        }

       

        public bool ConfirmOldPassword(int userID, string password)
        {
            return service.ConfirmOldPassword(new ConfirmOldPasswordRequest() {
                userID = userID,
                oldPassword = password
            }).Status;
        }

        public string GetCountry(int countryID)
        {
            var vare = service.GetCountries().CountryList.Where(x=>x.Key == countryID).SingleOrDefault().Value;
            return vare;
        }
    }
}