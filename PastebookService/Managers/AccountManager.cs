
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

        public bool CreateUserAccount(UserRequest request)
        {
            string salt = null;

            string passwordHash = passwordManager.GeneratePasswordHash(request.PASSWORD, out salt);

            PB_USER user = new PB_USER()
            {
                USER_NAME = request.USER_NAME,
                PASSWORD = passwordHash,
                SALT = salt,
            };

            //int result = 0;//dataAccess.RegisterUser(user);

            return false;
        }

        

        
    }
}