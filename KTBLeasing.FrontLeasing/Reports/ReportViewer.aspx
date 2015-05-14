<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="KTBLeasing.FrontLeasing.Reports.ReportViewer" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%-- Fix for show SSRS report on Chrome and Safari   --%><script src="../scripts/jquery-1.5.1.js"
        type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            if (navigator.userAgent.toLowerCase().indexOf("webkit") >= 0) {
                Sys.Application.add_init(function () {
                    var prm = Sys.WebForms.PageRequestManager.getInstance();
                    if (!prm.get_isInAsyncPostBack()) {
                        prm.add_endRequest(function () {
                            var divs = $('table[id*=_fixedTable] > tbody > tr:last > td:last > div')
                            divs.each(function (idx, element) {
                                $(element).css('overflow', 'visible');
                            });
                        });
                    }
                });
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="_fixedTable">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="rptViewer" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="100%" 
            Width="100%">
        </rsweb:ReportViewer>
    
    </div>
    </form>
</body>
</html>
