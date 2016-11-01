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
        AccountManager accountManager = new AccountManager();
        PostManager postManager = new PostManager();
        FriendManager friendManager = new FriendManager();

        [HttpGet]
        public ActionResult Index()
        {
            SignupViewModel model = new SignupViewModel();
            model.countryList = accountManager.GetCountries();
            return View(model);
        }

        public JsonResult ValidateAccount(string email, string password)
        {
            UserModel user = new UserModel();
            bool status = false;
            if (status = accountManager.ValidateAccount(email, password, out user))
            {
                Session["username"] = user.USER_NAME;
                Session["id"] = user.ID;
            }
            return Json(new { Status = status }, JsonRequestBehavior.AllowGet);
        }

        //[Authorization]
        public ActionResult Home()
        {
            UserModel model = accountManager.GetAccount((string)Session["username"]);
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Pastebook");
        }

        [HttpPost]
        public ActionResult RegisterAccount(SignupViewModel model)
        {
            UserModel userModel = model.signup;

            if (ModelState.IsValid)
            {
                if (accountManager.RegisterAccount(ref userModel))
                {
                    model.signup = userModel;
                    Session["username"] = userModel.USER_NAME;
                    Session["id"] = userModel.ID;
                    return RedirectToAction("Home", "Pastebook");
                }
                return RedirectToAction("Index");
            }
            else
            {
                model.countryList = accountManager.GetCountries();
                return View("Index", model);
            }
        }

        //[Authorization]
        public ActionResult ViewFriendList()
        {
            List<GetFriendsList_Result> friendsList = friendManager.GetFriendList((int)Session["id"]);
            return View(friendsList);
        }

        [HttpPost]
        //[Authorization]
        public ActionResult EditProfile(UserModel model, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength < 2097152)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    model.PROFILE_PIC = ms.GetBuffer();
                }
            }
            if (accountManager.EditAccount(ref model))
            {
                model = accountManager.GetAccount(model.USER_NAME);
                Session["username"] = model.USER_NAME;
                return RedirectToAction("ViewProfile", "Pastebook", new { username = model.USER_NAME });
            }

            return RedirectToAction("Home");
        }

        [HttpPost]
        //[Authorization]
        public ActionResult UpdatAccount(SettingsViewModel model)
        {
            int mobileNum = 1;
            if (int.TryParse(model.signup.MOBILE_NO, out mobileNum))
            {
                UserModel user = model.signup;
                if (accountManager.EditAccount(ref user))
                {
                    user = accountManager.GetAccount(user.USER_NAME);
                    Session["username"] = user.USER_NAME;
                    return RedirectToAction("ViewProfile", "Pastebook", new { username = user.USER_NAME });
                }
                return RedirectToAction("Home");
            }
            ModelState.AddModelError("signup.MOBILE_NO", "Invalid Mobile Number");
            model.countryList = accountManager.GetCountries();
            return View("Settings", model);
        }

        //[Authorization]
        public ActionResult UpdatAccount(string email, string password)
        {
            if (password.Length > 0)
            {
                UserModel model = accountManager.GetAccount((string)Session["username"]);
                if (email.Length > 0)
                {
                    model.EMAIL = email;
                }
                model.PASSWORD = password;
                if (accountManager.EditAccountPassword(ref model))
                {
                    model = accountManager.GetAccount(model.USER_NAME);
                    return RedirectToAction("Settings", "Pastebook");
                }

                return RedirectToAction("Home");
            }
            return RedirectToAction("Settings", "Pastebook");
        }

        //[Route("Pastebook/{username}")]
        //[Authorization]
        public ActionResult ViewProfile(string username)
        {
            UserModel model;
            if (username != null)
            {
                model = accountManager.GetAccount(username);
                ViewBag.FriendshipStatus = friendManager.CheckFriendshipStatus((int)Session["id"], model.ID);
            }
            else
            {
                model = accountManager.GetAccount((string)Session["username"]);
            }
            Session["country"] = accountManager.GetCountry(model.COUNTRY_ID);
            return View(model);
        }

        //[Authorization]
        public ActionResult Settings()
        {
            SettingsViewModel mainModel = new SettingsViewModel();
            mainModel.countryList = accountManager.GetCountries();
            mainModel.signup = accountManager.GetAccount((string)Session["username"]);
            return View(mainModel);
        }

        public JsonResult ConfirmOldPassword(string password)
        {
            return Json(new { Status = accountManager.ConfirmOldPassword((int)Session["id"], password) },
                JsonRequestBehavior.AllowGet);
        }

        //[Authorization]
        public ActionResult ViewPosts(int ID)
        {
            ViewPostsModel model = new ViewPostsModel();
            if (Session["page"].ToString() == "Home")
            {
                model.postList = postManager.GetNewsfeed(ID);
            }
            else
            {
                model.postList = postManager.UserTimeline(ID);
            }

            model.user = accountManager.GetAccount((string)Session["username"]);
            model.profileOwner = accountManager.GetAccount(ID);
            return PartialView("ViewPosts", model);
        }

        //[Route("Pastebook/posts/{postID}")]
        //[Authorization]
        public ActionResult PreviewPost(int postID)
        {
            CompletePost model = postManager.GetPost(postID);
            model.post.ID = postID;
            return View("PreviewPost", model);
        }

        //[Authorization]
        public ActionResult PublishPost(string postString, int profileOwner)
        {
            postString = postString.Trim();
            return Json(new { Status = postManager.PublishNewPost((int)Session["id"], profileOwner, postString) }, JsonRequestBehavior.AllowGet);
        }

        //[Authorization]
        public ActionResult CommentOnPost(int postID, string comment)
        {
            int posterID = (int)Session["id"];
            return Json(new { Status = postManager.CommentOnPost(posterID, postID, comment) }, JsonRequestBehavior.AllowGet);
        }

        //[Authorization]
        public ActionResult LikePost(int postID)
        {
            int likedBy = (int)Session["id"];
            return Json(new { Status = postManager.LikePost(postID, likedBy) }, JsonRequestBehavior.AllowGet);
        }

        //[Authorization]
        public JsonResult GetAllNotifications()
        {
            NotificationManager notifManager = new NotificationManager();
            int count = 0;
            count = notifManager.GetNotificationCount((int)Session["id"]);
            return Json(new { Status = count }, JsonRequestBehavior.AllowGet);
        }

        //[Authorization]
        public ActionResult Notifications()
        {
            NotificationManager notifManager = new NotificationManager();
            List<NotificationViewModel> model = notifManager.GetNotification((int)Session["id"]);
            return PartialView("Notifications", model);
        }

        //[Authorization]
        public ActionResult Notification()
        {
            NotificationManager notifManager = new NotificationManager();
            List<NotificationViewModel> model = notifManager.GetNotification((int)Session["id"]);
            return View(model);
        }

        [HttpPost]
        //[Authorization]
        public ActionResult SearchUsers(string name)
        {
            if (name.Length > 0)
            {
                List<User> userList = accountManager.SearchAccount(name);
                return View(userList.ToList());
            }
            return RedirectToAction("Home", "Pastebook");
        }

        public JsonResult SendFriendRequest(int friendID)
        {
            return Json(new { Status = friendManager.SendFriendRequest((int)Session["id"], friendID) },
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult RespondToFriendRequest(int friendID, bool accept)
        {
            return Json(new
            {
                Status = friendManager.RespondToFriendRequest((int)Session["id"], friendID, accept)
            },
                JsonRequestBehavior.AllowGet);
        }
    }
}