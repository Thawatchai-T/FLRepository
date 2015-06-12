using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using KTBLeasing.FrontLeasing.Domain;
using System.IO;
using log4net;
using System.Reflection;

namespace KTBLeasing.FrontLeasing.Reports
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<Installment> list = new List<Installment>();
                Restructure entity = new Restructure();

                if (Session["Installment"] != null && Session["Restructure"] != null)
                {
                    list = (List<Installment>)Session["Installment"];
                    entity = (Restructure)Session["Restructure"];
                }

                ShowLocalReport(list, entity);
                Session.Clear();
            }
        }

        protected void ShowLocalReport(List<Installment> list, Restructure entity)
        {
            try
            {
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                List<Restructure> listentity = new List<Restructure>();
                listentity.Add(entity);

                ReportDataSource dsInstallment = new ReportDataSource("Installment", list);
                ReportDataSource dsRestructure = new ReportDataSource("Restructure", listentity);
                //rptViewer = new Microsoft.Reporting.WebForms.ReportViewer();
                //rptViewer.ProcessingMode = ProcessingMode.Local;
                //rptViewer.LocalReport.ReportPath = Server.MapPath("Installment.rdlc");
                //rptViewer.LocalReport.DataSources.Clear();
                //rptViewer.LocalReport.DataSources.Add(dsInstallment);
                //rptViewer.LocalReport.DataSources.Add(dsRestructure);

                //rptViewer.LocalReport.Refresh();

                

                //byte[] bytes = rptViewer.LocalReport.Render("EXCEL",null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                //// Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                //Response.Buffer = true;
                //Response.Clear();
                //Response.ContentType = mimeType;
                //Response.AddHeader("content-disposition", "attachment; filename=" + "Installment" + "." + extension);
                //Response.BinaryWrite(bytes); // create the file
                //Response.Flush();
                //Response.End();


                LocalReport report = new LocalReport();
                report.ReportPath = Server.MapPath("Installment.rdlc"); 
                //ReportDataSource rds = new ReportDataSource();
                //rds.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                //rds.Value = EmployeeRepository.GetAllEmployees();
                //report.DataSources.Add(rds);
                //report.DataSources
                //report.ReportPath = Server.MapPath("Installment.rdlc");
                report.DataSources.Clear();
                report.DataSources.Add(dsInstallment);
                report.DataSources.Add(dsRestructure);

                //Byte[] mybytes = report.Render("EXCEL");
                byte[] bytes = report.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=" + "Installment" + "." + extension);
                Response.BinaryWrite(bytes); // create the file
                Response.Flush();
                Response.End();
                //Byte[] mybytes = report.Render("PDF"); for exporting to PDF
                //using (FileStream fs = File.Create(@"D:\SalSlip.xls"))
                //{
                //    fs.Write(mybytes, 0, mybytes.Length);
                //}
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }
}