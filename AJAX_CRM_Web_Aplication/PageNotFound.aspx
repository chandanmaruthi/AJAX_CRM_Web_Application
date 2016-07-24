<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageNotFound.aspx.cs" Buffer="false"  Inherits="PageNotFound" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table width="700px" align="center" ><tr><td>
    
    
    <div style="width:600px;vertical-align:middle;border:solid 5px #cccccc;background-color:#f5f5f5;padding:20px;margin-top:200px;" >
    <div style="width:600px;height:60px;font-size:20px;font-family:Arial;color:#404040;text-align:center;">Oops ! The requested page does not exist</div>
    <div style="width:600px;height:30px;font-size:14px;font-family:Arial;">We think your URL is not valid please check the url and try again. </div>
    <div style="width:600px;height:30px;font-size:14px;font-family:Arial;">To Reach a Company HelpDesk, Please Type the First Word of tne Company Name </div>
    <div style="width:600px;height:60px;font-size:14px;font-family:Arial;"><input id="txtSearchString" runat=server style="width:200px;height:30px;font-size:20px;" />
    <asp:LinkButton runat=server ID="lnlSearchPortal" Text="Find My Portal" 
            onclick="lnlSearchPortal_Click" ></asp:LinkButton>
    <div style="width:600px;font-size:14px;font-family:Arial;">
    <asp:Repeater runat=server ID="rptrPortalLinks">
    <ItemTemplate>
    <b>
    <a href="<%# CustomerSupport.Utility.SysResource.HomePath+Eval("Account_Name").ToString() %>"><%# CustomerSupport.Utility.SysResource.HomePath+Eval("Account_Name").ToString() %>    </a>
    
    
    </b>
    </ItemTemplate>
    </asp:Repeater>
    
    </div>
      </div>
    
    </div>
    </td></tr></table>
    
    </form>
</body>
</html>
