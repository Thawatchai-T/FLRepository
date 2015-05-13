using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using KTBLeasing.FrontLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Reports
{
    public partial class ReportViewer : System.Web.UI.Page
    {
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
                List<Restructure> listentity = new List<Restructure>();
                listentity.Add(entity);

                ReportDataSource dsInstallment = new ReportDataSource("Installment", list);
                ReportDataSource dsRestructure = new ReportDataSource("Restructure", listentity);
                //rptViewer = new Microsoft.Reporting.WebForms.ReportViewer();
                rptViewer.ProcessingMode = ProcessingMode.Local;
                rptViewer.LocalReport.ReportPath = Server.MapPath("Installment.rdlc");
                rptViewer.LocalReport.DataSources.Clear();
                rptViewer.LocalReport.DataSources.Add(dsInstallment);
                rptViewer.LocalReport.DataSources.Add(dsRestructure);

                rptViewer.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

            }
        }

    }
}