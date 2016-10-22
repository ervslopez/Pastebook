using PastebookApp.Managers;
using PastebookApp.Models;
using PastebookApp.PastebookService;
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
        PostManager postManager = new PostManager();
        FriendManager friendManager = new FriendManager();

        [HttpGet]
        public ActionResult Index()
        {
            SignupViewModel model = new SignupViewModel();
            model.countryList = signupManager.GetCountries();
            return View(model);
        }
        
        public ActionResult Home()
        {
            UserModel model = signupManager.GetAccount((string)Session["username"]);
            return View(model);
        }
        
        public ActionResult ViewFriendList()
        {
            List<GetFriendsList_Result> friendsList = friendManager.GetFriendList((int)Session["id"]);
            return View(friendsList);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult ValidateAccount(SignupViewModel model)
        {
            UserModel user = new UserModel();
            if (signupManager.ValidateAccount(model.login.email, model.login.password, out user))
            {
                Session["username"] = user.USER_NAME;
                Session["id"] = user.ID;
                return RedirectToAction("Home", "Pastebook", new { username = user.USER_NAME });
            }
            return RedirectToAction("Index");
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
                return RedirectToAction("Home", "Pastebook", new { username = model.signup.USER_NAME });
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult ViewProfile(string username)
        {
            UserModel model;
            if (username != null)
            {
                model = signupManager.GetAccount(username);
            }else
            {
                model = signupManager.GetAccount((string)Session["username"]);
            }
            return View(model);
        }
        // post related functions
        public ActionResult ViewPosts(int ID)
        {
            ViewPostsModel model = new ViewPostsModel();
            model.postList = postManager.GetNewsfeed(ID);
            model.user = signupManager.GetAccount((string)Session["username"]);
            return PartialView("ViewPosts", model);
        }

        public ActionResult PublishPost(string postString)
        {
            return Json(new { Status = postManager.PublishNewPost((int)Session["id"], postString) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CommentOnPost(int postID, string comment)
        {
            int posterID = (int)Session["id"];
            return Json(new { Status = postManager.CommentOnPost(posterID, postID, comment) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LikePost(int postID)
        {
            int likedBy = (int)Session["id"];
            return Json(new { Status = postManager.LikePost(postID, likedBy) }, JsonRequestBehavior.AllowGet);
        }
        // end of post related functions

        //public ActionResult GetNotifications()
        //{

        //}

        public ActionResult GetFriendList()
        {
            int posterID = (int)Session["id"];

            return null;
        }
    }
}