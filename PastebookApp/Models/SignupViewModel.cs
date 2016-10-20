using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PastebookApp.Models
{
    public class SignupViewModel
    {
        public UserModel signup { get; set; }
        public LoginCredentials login { get; set; }
        public SelectList countryList;
    }
}