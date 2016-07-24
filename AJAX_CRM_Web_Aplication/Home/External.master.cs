using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CustomerSupport;
/// <summary>
/// Summary description for Internal
/// </summary>
public partial class External : System.Web.UI.MasterPage
{
    CustomerSupport.CustomerSupportPage objPage = new CustomerSupport.CustomerSupportPage();
    public External()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CustomerSupportPage objPage = new CustomerSupportPage();
        lnkCss.Href = CustomerSupport.Utility.SysResource.HomePath + "common/css/web.css";

        //if (objPage.GetState(CustomerSupport.CustomerSupportPage.IsLoggedIn) == "1")
        //{
            //dvMenu.Visible = true;
            //dvSignUpBox.Visible = false;
            ////dvWelcomeBox.Visible = true;
            //lblWelcomeUser.Text = "Welcome " + objPage.GetState(CustomerSupport.CustomerSupportPage.UserName);
            //lnkSignout.Visible = true;
        //}
        //else
        //{
        //    dvSignUpBox.Visible = true;
        //    dvWelcomeBox.Visible = false;
        //    dvMenu.Visible = false;
        //    lnkSignout.Visible = false;
        //}
    }
    protected void lnkSignout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();

        Response.Cookies[objPage.GetState(CustomerSupport.CustomerSupportPage.AccountID)].Value = null;
        HttpContext.Current.Session.Abandon();
        Response.Cookies.Clear();
        Server.ClearError();
        objPage.SetState(CustomerSupport.CustomerSupportPage.IsLoggedIn, "0");
        Response.Redirect("Default.aspx");
    }
}
