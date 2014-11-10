using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KTBLeasing.FrontLeasing.WsLoginAD;
using KTBLeasing.FrontLeasing.Models;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class HomeController : Controller
    {
        //private IWS_LoginAD _LoginService;
        //public IWS_LoginAD LoginService(IWS_LoginAD loginservice)
        //{
        //    return this._LoginService = loginservice;
        //}
        
        //
        // GET: /Home/

        public ActionResult Index()
        {
            
            return View();
        }

        public JsonResult LoginWindow()
        {
            //var values = _objDefault1Controller.Get();

            return null;// Json(values, JsonRequestBehavior.AllowGet);
        }

        //public bool VerifyAD(User user)
        //{
        //    if (user.UserName == "root" && user.Password == "root")
        //    {
        //        return true;
        //    }
        //    LoginADRequest Request = new LoginADRequest(user.UserName, user.Password);
        //    var result = _LoginService.LoginAD(Request);
        //    return (result.Equals("OK")) ? true : false;
        //}

    }
}
