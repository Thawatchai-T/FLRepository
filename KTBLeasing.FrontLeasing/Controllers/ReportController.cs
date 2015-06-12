using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing.Reports;
using DocumentFormat.OpenXml;
using ExportToExcel;
using log4net;
using System.Reflection;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace KTBLeasing.FrontLeasing.Controllers
{
    public class ReportController : Controller
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        //
        // GET: /Report/

        public ActionResult Index()
        {
            return View();
        }

        #region "To ReportViewer"
        public JsonResult SSRSReport(List<Installment> list, Restructure entity)
        {
            Session["Installment"] = list;
            Session["Restructure"] = entity;

            return Json(new { url = Url.Content("~/Reports/ReportViewer.aspx") }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //public ActionResult SSRSReport(List<Installment> list, Restructure entity)
        //{
        //    try
        //    {
        //        Warning[] warnings;
        //        string[] streamIds;
        //        string mimeType = string.Empty;
        //        string encoding = string.Empty;
        //        string extension = string.Empty;

        //        List<Restructure> listentity = new List<Restructure>();
        //        listentity.Add(entity);

        //        ReportDataSource dsInstallment = new ReportDataSource("Installment", list);
        //        ReportDataSource dsRestructure = new ReportDataSource("Restructure", listentity);

        //        LocalReport report = new LocalReport();
        //        report.ReportPath = Server.MapPath("Installment.rdlc");
        //        report.DataSources.Clear();
        //        report.DataSources.Add(dsInstallment);
        //        report.DataSources.Add(dsRestructure);

        //        byte[] bytes = report.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

        //        Response.Buffer = true;
        //        Response.Clear();
        //        Response.ContentType = mimeType;
        //        Response.AddHeader("content-disposition", "attachment; filename=" + "Installment" + "." + extension);
        //        Response.BinaryWrite(bytes); // create the file
        //        Response.Flush();
        //        Response.End();

        //        return View("Report");
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex);
        //        return null;
        //    }
        //}
    }
}
