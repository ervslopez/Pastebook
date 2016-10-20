using PastebookApp.Managers;
using PastebookApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PastebookApp.Controllers
{
    public class PastebookController : Controller
    {
        SignupManager signupManager = new SignupManager();

        [HttpGet]
        public ActionResult Index()
        {
            SignupViewModel model = new SignupViewModel();
            model.countryList = signupManager.GetCountries();
            return View(model);
        }
        
        public ActionResult Home(UserModel model)
        {
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult ValidateAccount(SignupViewModel model)
        {
            UserModel user = new UserModel();
            if(signupManager.ValidateAccount(model.login.email, model.login.password, out user))
            {
                return View("Home", user);
            }
            return View("Index");
        }

        public ActionResult RegisterAccount(SignupViewModel model, HttpPostedFileBase file)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                file.InputStream.CopyTo(ms);
                model.signup.PROFILE_PIC = ms.GetBuffer();
            }

            if (signupManager.RegisterAccount(model.signup))
            {
                return View("Home", model.signup);
            }
            return RedirectToAction("Index");
        }
    }
}