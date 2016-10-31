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

        public ActionResult Home()
        {
            if (Session["username"] != null)
            {
                UserModel model = accountManager.GetAccount((string)Session["username"]);
                return View(model);
            }
            return RedirectToAction("Index", "Pastebook");
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

        //[Route("Pastebook/friends/")]
        public ActionResult ViewFriendList()
        {
            if (Session["username"] != null)
            {
                List<GetFriendsList_Result> friendsList = friendManager.GetFriendList((int)Session["id"]);
                return View(friendsList);
            }
            return RedirectToAction("Index", "Pastebook");
        }

        [HttpPost]
        public ActionResult EditProfile(UserModel model, HttpPostedFileBase file)
        {
            if (Session["username"] != null)
            {
                if (file != null && file.ContentLength < 300000)
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
            return RedirectToAction("Index", "Pastebook");
        }

        [HttpPost]
        public ActionResult UpdatAccount(SettingsViewModel model)
        {
            if (Session["username"] != null)
            {
                UserModel user = model.signup;
                if (accountManager.EditAccount(ref user))
                {
                    user = accountManager.GetAccount(user.USER_NAME);
                    return RedirectToAction("ViewProfile", "Pastebook", new { username = user.USER_NAME });
                }
                return RedirectToAction("Home");
            }
            return RedirectToAction("Index", "Pastebook");
        }

        public ActionResult UpdatAccount(string email, string password)
        {
            if (Session["username"] != null)
            {
                UserModel model = accountManager.GetAccount((string)Session["username"]);
                model.EMAIL = email;
                model.PASSWORD = password;
                if (accountManager.EditAccountPassword(ref model))
                {
                    model = accountManager.GetAccount(model.USER_NAME);
                    return RedirectToAction("Home", "Pastebook");
                }

                return RedirectToAction("Home");
            }
            return RedirectToAction("Index", "Pastebook");
        }

        //[Route("Pastebook/{username}")]
        public ActionResult ViewProfile(string username)
        {
            if (Session["username"] != null)
            {
                UserModel model;
                if (username != null)
                {
                    model = accountManager.GetAccount(username);
                    ViewBag.FriendshipStatus = friendManager.CheckFriendshipStatus((int)Session["id"],model.ID);
                }
                else
                {
                    model = accountManager.GetAccount((string)Session["username"]);
                }
                Session["country"] = accountManager.GetCountry(model.COUNTRY_ID);
                return View(model);
            }
            return RedirectToAction("Index", "Pastebook");
        }

        public ActionResult Settings()
        {
            if (Session["username"] != null)
            {
                SettingsViewModel mainModel = new SettingsViewModel();
                mainModel.countryList = accountManager.GetCountries();
                mainModel.signup = accountManager.GetAccount((string)Session["username"]);
                return View(mainModel);
            }
            return RedirectToAction("Index", "Pastebook");
        }

        public JsonResult ConfirmOldPassword(string password)
        {
            return Json(new { Status = accountManager.ConfirmOldPassword((int)Session["id"], password) }, 
                JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewPosts(int ID)
        {
            if (Session["username"] != null)
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
            return RedirectToAction("Index", "Pastebook");
        }

        //[Route("Pastebook/posts/{postID}")]
        public ActionResult PreviewPost(int postID)
        {
            if (Session["username"] != null)
            {
                CompletePost model = postManager.GetPost(postID);
                model.post.ID = postID;
                return View("PreviewPost", model);
            }
            return RedirectToAction("Index", "Pastebook");
        }

        public ActionResult PublishPost(string postString, int profileOwner)
        {
            if (Session["username"] != null)
            {
                return Json(new { Status = postManager.PublishNewPost((int)Session["id"], profileOwner, postString) }, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("Index", "Pastebook");
        }

        public ActionResult CommentOnPost(int postID, string comment)
        {
            if (Session["username"] != null)
            {
                int posterID = (int)Session["id"];
                return Json(new { Status = postManager.CommentOnPost(posterID, postID, comment) }, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("Index", "Pastebook");
        }

        public ActionResult LikePost(int postID)
        {
            if (Session["username"] != null)
            {
                int likedBy = (int)Session["id"];
                return Json(new { Status = postManager.LikePost(postID, likedBy) }, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("Index", "Pastebook");
        }

        public JsonResult GetAllNotifications()
        {
            NotificationManager notifManager = new NotificationManager();
            int count = 0;
            if ((string)Session["username"] != null)
            {
                count = notifManager.GetNotificationCount((int)Session["id"]);
            }
            return Json(new { Status = count }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Notifications()
        {
            NotificationManager notifManager = new NotificationManager();
            List<NotificationViewModel> model = notifManager.GetNotification((int)Session["id"]);
            return PartialView("Notifications", model);
        }

        [HttpPost]
        public ActionResult SearchUsers(string name)
        {
            if (Session["username"] != null)
            {
                if (name.Length > 0)
                {
                    List<User> userList = accountManager.SearchAccount(name);
                    return View(userList.ToList());
                }
                return RedirectToAction("Home", "Pastebook");
            }
            return RedirectToAction("Index", "Pastebook");
        }

        public JsonResult SendFriendRequest(int friendID)
        {
            return Json(new { Status = friendManager.SendFriendRequest((int)Session["id"], friendID) }, 
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult RespondToFriendRequest(int friendID, bool accept)
        {
            return Json(new {
                Status = friendManager.RespondToFriendRequest((int)Session["id"], friendID, accept) }, 
                JsonRequestBehavior.AllowGet);
        }
    }
}