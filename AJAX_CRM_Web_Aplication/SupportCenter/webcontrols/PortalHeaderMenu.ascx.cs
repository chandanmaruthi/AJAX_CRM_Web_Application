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
using CustomerSupport.Data;
public partial class PortalHeaderMenu : CustomerSupportControl
{
    CustomerSupport.CustomerSupportPage objPage = new CustomerSupport.CustomerSupportPage();
    public bool bolShowCorpMenu;
    int intTab = 0;
    //bool bolShowSettings = false;
    public string strTab1 = "WebMenuTab", strTab2 = "WebMenuTab", strTab3 = "WebMenuTab", strTab4 = "WebMenuTab", strTab5 = "WebMenuTab", strTab6 = "WebMenuTab";
    public string strNewCount = "0", strQalifiedCount = "0", strQuoteCount = "0", strWonCount = "0", strLostCount = "0";
    public string strShowLogo = "none";
    public string strAccountName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (GetState(CustomerSupport.CustomerSupportControl.Logo_File) == "")
            { strShowLogo = "none"; }
            else { strShowLogo = "block"; }

            strAccountName = GetState(CustomerSupportControl.Account_Name);

            if (GetState(CustomerSupportControl.Logo_File).Length > 0)
            {
                divLogo.Visible = true;
                imgLogo.ImageUrl = CustomerSupport.Utility.SysResource.UserData + "userimages/" + GetState(CustomerSupportPage.AccountID) + "/" + GetState(CustomerSupportPage.Logo_File);
            }
            if (objPage.GetState(CustomerSupport.CustomerSupportPage.IsLoggedIn) == "1")
            {
                dvWelcomeBox.Visible = true;
                divLogin.Visible = false;
                lblWelcomeUser.Text = "Welcome " + objPage.GetState(CustomerSupport.CustomerSupportPage.UserName);
                lnkSignout.Visible = true;

                switch (SetTab)
                {
                    case 1: strTab1 = "WebMenuTabActive"; break;
                    case 2: strTab2 = "WebMenuTabActive"; break;
                    case 3: strTab3 = "WebMenuTabActive"; break;
                    case 4: strTab4 = "WebMenuTabActive"; break;
                    case 5: strTab5 = "WebMenuTabActive"; break;
                    case 6: strTab6 = "WebMenuTabActive"; break;
                    default: strTab6 = "WebMenuTab"; break;
                }
            }
            else
            {
                //dvSignUpBox.Visible = true;
                dvWelcomeBox.Visible = false;
                divLogin.Visible = true;
                //HeaderMenu.Visible = false;
                lnkSignout.Visible = false;
            }
        }
        catch
        {
            throw;
        }
    }

    protected void lnkSignout_Click(object sender, EventArgs e)
    {
        try
        {
            FormsAuthentication.SignOut();

            Response.Cookies[objPage.GetState(CustomerSupport.CustomerSupportPage.AccountID)].Value = null;
            HttpContext.Current.Session.Abandon();
            Response.Cookies.Clear();
            Server.ClearError();
            objPage.SetState(CustomerSupport.CustomerSupportPage.IsLoggedIn, "0");
            Response.Redirect(CustomerSupport.Utility.SysResource.HomePath + "/" + GetState(CustomerSupport.CustomerSupportPage.Account_Name));
        }
        catch
        {
            throw;
        }
        //CustomerSupport.CustomerSupportControl.Header_TextInActive_Tab_Bg_Color

    }

    public int SetTab
    {
        get { return intTab; }
        set { intTab = value; }
    }
}
