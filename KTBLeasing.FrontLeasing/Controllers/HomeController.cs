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
        public JsonResult Upload(IEnumerable<HttpPostedFileBase> files)
        {
            try
            {
                foreach(var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/Uploads"), fileName);
                        file.SaveAs(path);
                    }
                }
                return Json(new { success = true , message = "อัพโหลดไฟล์เรียบร้อยแล้ว"}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false , message = "ไม่สามารถอัพโหลดไฟล์" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public string DoPost(string data)
        {
            try
            {
                //ApplicationDetailRepository.Update(entity);
                //ApplicationDetailRepository.Insert(entity);
                //ApplicationDetailViewModel datform = JsonConvert.DeserializeObject<ApplicationDetailViewModel>(data);
                var a = 1;
            }
            catch (Exception e)
            {
                //Logger.Error(e);
            }
            return "string";
        }
    }
}
