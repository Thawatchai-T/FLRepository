using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KTBLeasing.FrontLeasing.WsLoginAD;
using KTBLeasing.FrontLeasing.Models;
using System.Web.Security;
using System.IO;

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

        [HttpPost]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> files)
        {
            try
            {
                // Verify that the user selected a file
                foreach(var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        // extract only the fielname
                        var fileName = Path.GetFileName(file.FileName);
                        // store the file inside ~/App_Data/uploads folder
                        var path = Path.Combine(Server.MapPath("~/App_Data/Uploads"), fileName);
                        file.SaveAs(path);
                    }
                }
                // redirect back to the index action to show the form once again
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
