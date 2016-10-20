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
    public class SignupManager
    {
        Service1Client service = new Service1Client();

        public SelectList GetCountries()
        {
            return new SelectList(service.GetCountries().CountryList, "Key", "Value"); 
        }

        public bool ValidateAccount(string email, string password, out UserModel model)
        {
            LoginResponse resp = service.LoginUserAccount(new LoginRequest() {
                email = email,
                password = password
            });
            model = UserMapper.ToUserModel(resp.user);
            return resp.Status;
        }

        public bool RegisterAccount(UserModel model)
        {
            CreateUserResponse resp = service.CreateUserAccount(new UserRequest() {
                user = UserMapper.ToUser(model)
            });
            return resp.Status;
        }

        private UserModel GetAccount(string username)
        {
            UserModel model = new UserModel();
            GetAccountProfileResponse resp = service.GetAccountProfile(new GetAccountProfileRequest() {
                username = username
            });
            model = UserMapper.ToUserModel(resp.user);
            return model;
        }

    }
}