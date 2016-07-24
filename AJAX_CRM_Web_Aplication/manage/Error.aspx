<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" Title="Opps !" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <table align="center" border="0">
            <tr>
                <td>
                    <div style="width: 300px; height: 300px;" align="center">
                        <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>">
                            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>ErrorMessage.gif" border="0" /></a>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
