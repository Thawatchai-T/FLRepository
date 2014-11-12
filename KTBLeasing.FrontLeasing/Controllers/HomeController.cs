using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KTBLeasing.FrontLeasing.WsLoginAD;
using KTBLeasing.FrontLeasing.Models;
using System.Web.Security;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            //{
            //    var value = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);

            //    if (value.Expired)
            //    {
            //        return View();
            //    }
            //}
            //FormsAuthentication.SignOut();
            return View();
        }

        public ActionResult Login()
        {
            //var values = _objDefault1Controller.Get();

            return View("Login");// Json(values, JsonRequestBehavior.AllowGet);
        }
    }
}
