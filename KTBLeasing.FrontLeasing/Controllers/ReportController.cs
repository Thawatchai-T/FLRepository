using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing.Reports;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult Index()
        {
            return View();
        }

        //public JsonResult ViewReport(string reportname, string[] paralist)
        //{
        //    if (paralist.Count() > 0 && JsonConvert.DeserializeObject<string>(reportname) != "CustomizePivot")
        //    {
        //        var listJsonResult = JsonConvert.DeserializeObject<List<ParaName>>(paralist[0]);
        //        Dictionary<string, string> dicpara = new Dictionary<string, string>();
        //        foreach (var items in listJsonResult)
        //        {
        //            dicpara.Add(items.name, items.value);
        //        }

        //        return SSRSReport(JsonConvert.DeserializeObject<string>(reportname), dicpara);
        //    }
        //    else
        //    {
        //        Dictionary<string, string> dicpara = new Dictionary<string, string>();
        //        dicpara.Add(string.Empty, string.Empty);

        //        return SSRSReport(JsonConvert.DeserializeObject<string>(reportname), dicpara);
        //    }
        //}

        public JsonResult SSRSReport(List<Installment> list, Restructure entity)
        {
            Session["Installment"] = list;
            Session["Restructure"] = entity;

            return Json(new { url = Url.Content("~/Reports/ReportViewer.aspx") }, JsonRequestBehavior.AllowGet);
        }
    }
}
