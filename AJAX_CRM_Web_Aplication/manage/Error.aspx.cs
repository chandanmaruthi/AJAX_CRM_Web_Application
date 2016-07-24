using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CustomerSupport;
using System.Diagnostics;
public partial class Error : CustomerSupportPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        email objEmail = new email();
        //bool bolResult;
        Exception LastError;
        LastError = Server.GetLastError();
        if (LastError != null)
        {
            Response.Write("aaa" + LastError.ToString());
            //bolResult = objEmail.Sendmail(CustomerSupport.Utility.SysResource.FromID, CustomerSupport.Utility.SysResource.FromID, "Error", Server.GetLastError());
        }
        //Response.Write("Error");
        Session.Abandon();
        Response.Cookies.Clear();
        Server.ClearError();

        FormsAuthentication.SignOut();
        SetState(CustomerSupport.CustomerSupportPage.IsLoggedIn, "0");

    }
}
