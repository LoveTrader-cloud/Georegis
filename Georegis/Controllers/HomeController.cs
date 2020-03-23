using Georegis.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Georegis.Controllers
{
    public class HomeController : MasterController
    {
        public ActionResult Index()
        {

            return View();
        }

        [Authorize]
        public ActionResult Footer()
        {
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string name = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString();

            var info = new AssemblyInfo { FullName = name, Version = version };
            return PartialView(info);
        }

        [Authorize]
        public ViewResult GetUser() => View(CurrentUser);

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