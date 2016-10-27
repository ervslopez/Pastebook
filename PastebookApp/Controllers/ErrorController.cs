using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PastebookApp.Controllers
{
    public class ErrorController : Controller
    {

        public ActionResult Global()
        {
            return View();
        }

        public ActionResult Error404()
        {
            return View();
        }
    }
}