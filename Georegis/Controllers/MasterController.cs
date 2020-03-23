using Georegis.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Georegis.Helpers;

namespace Georegis.Controllers
{
    public class MasterController : Controller
    {

        /// <summary>
        /// Пользователь и вся информация о нем
        /// </summary>
        protected CurrentUserViewModel CurrentUser;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            CurrentUser = UserHelper.GetCurrentUser(HttpContext.User.Identity.Name);
            ViewBag.BrowserVersion = Request.Browser.Version;
            ViewBag.BrowserPlatform = Request.Browser.Platform;
            ViewBag.BrowserEcmaScriptVersion = Request.Browser.EcmaScriptVersion;
            ViewBag.Browser = Request.Browser.Browser;
            ViewBag.OldBrowser = Request.Browser.MajorVersion <= 9 && (Request.Browser.Browser.Equals("InternetExplorer") || Request.Browser.Browser.Equals("IE"));

        }
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }
    }
}