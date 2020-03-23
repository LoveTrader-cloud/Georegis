using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Georegis.Controllers
{
    public class HomeController : MasterController
    {
        public ActionResult Index(int page = 1)
        {
            var curuser = CurrentUser.FullName;
            return View(curuser);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}