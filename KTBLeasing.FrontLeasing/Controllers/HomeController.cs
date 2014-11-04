using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class HomeController : Controller
    {
        private Default1Controller _objDefault1Controller = new Default1Controller();
        
        //
        // GET: /Home/

        public ActionResult Index()
        {
            
            return View();
        }

        public JsonResult LoginWindow()
        {
            var values = _objDefault1Controller.Get();

            return Json(values, JsonRequestBehavior.AllowGet);
        }

    }
}
