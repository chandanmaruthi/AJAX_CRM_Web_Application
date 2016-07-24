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
public partial class Webcontrols_HeaderMenu : System.Web.UI.UserControl
{
    CustomerSupport.CustomerSupportPage objPage = new CustomerSupport.CustomerSupportPage();
    int intTab = 0;
    //bool bolShowSettings = false;
    public string strTab1 = "PageLink", strTab2 = "PageLink", strTab3 = "PageLink", strTab4 = "PageLink", strTab5 = "PageLink", strTab6 = "PageLink", strTab7 = "PageLink";
    public string strNewCount = "0", strQalifiedCount = "0", strQuoteCount = "0", strWonCount = "0", strLostCount = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        try{
        BindValues();
        if (objPage.GetState(CustomerSupport.CustomerSupportPage.IsLoggedIn) == "1")
        {
  

            switch (SetTab)
            {
                case 1: strTab1 = "PageLink_Active"; break;
                case 2: strTab2 = "PageLink_Active"; break;
                case 3: strTab3 = "PageLink_Active"; break;
                case 4: strTab4 = "PageLink_Active"; break;
                case 5: strTab5 = "PageLink_Active"; break;
                case 6: strTab6 = "PageLink_Active"; break;
                case 7: strTab7 = "PageLink_Active"; break;
                default: break;
            }
            
        }
        else
        {

        }
    }
    catch
    {
        throw;
    }
    }
    protected void BindValues()
    {
        try{
        CustomerSupportPage objPage = new CustomerSupportPage();
        string strAccountID = "";
        Account objAccount = new Account();
        DataSet objData;

        strAccountID = objPage.GetState(CustomerSupportPage.AccountID);
        if (strAccountID.Length > 0)
        {
            objData = objAccount.GetAccountSummary(strAccountID);
            if (objData.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < objData.Tables[0].Rows.Count; i++)
                {
                    switch (objData.Tables[0].Rows[i]["Status_Desc"].ToString())
                    {
                        case "New": strNewCount = objData.Tables[0].Rows[i]["Leads_Count"].ToString(); break;
                        case "Qualified": strQalifiedCount = objData.Tables[0].Rows[i]["Leads_Count"].ToString(); break;
                        case "Quote": strQuoteCount = objData.Tables[0].Rows[i]["Leads_Count"].ToString(); break;
                        case "Won": strWonCount = objData.Tables[0].Rows[i]["Leads_Count"].ToString(); break;
                        case "Lost": strLostCount = objData.Tables[0].Rows[i]["Leads_Count"].ToString(); break;
                        default: break;

                    }
                }

            }

        }
    }
    catch
    {
        throw;
    }
    }
    protected void lnkSignout_Click(object sender, EventArgs e)
    {
        try{
        FormsAuthentication.SignOut();

        Response.Cookies[objPage.GetState(CustomerSupport.CustomerSupportPage.AccountID)].Value = null;
        HttpContext.Current.Session.Abandon();
        Response.Cookies.Clear();
        Server.ClearError();
        objPage.SetState(CustomerSupport.CustomerSupportPage.IsLoggedIn, "0");
        Response.Redirect("Default.aspx");
    }
    catch
    {
        throw;
    }


    }

    public int SetTab
    {
        get { return intTab; }
        set { intTab = value; }
    }

}
