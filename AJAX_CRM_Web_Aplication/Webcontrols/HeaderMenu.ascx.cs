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
public partial class Webcontrols_HeaderMenu : CustomerSupportControl
{
    CustomerSupport.CustomerSupportPage objPage = new CustomerSupport.CustomerSupportPage();
    public bool bolShowCorpMenu;
    int intTab = 0;
    bool bolShowSettings = false;
    public string strTab1 = "MenuTab", strTab2 = "MenuTab", strTab3 = "MenuTab", strTab4 = "MenuTab", strTab5 = "MenuTab", strTab6 = "MenuTab";
    public string strNewCount = "0", strQalifiedCount = "0", strQuoteCount = "0", strWonCount = "0", strLostCount = "0";
    public string strShowLogo = "none";
    public string strAccountName = ""; 
    protected void Page_Load(object sender, EventArgs e)
    {
        try{
            //GetState(CustomerSupportControl.br)
        BindValues();
            if(GetState(CustomerSupport.CustomerSupportControl.Logo_File)=="") 
            {strShowLogo= "none";}
            else { strShowLogo = "block"; }
            strAccountName = GetState(CustomerSupportControl.Account_Name);
        if (objPage.GetState(CustomerSupport.CustomerSupportPage.IsLoggedIn) == "1")
        {
            //HeaderMenu.Visible = true;
            //dvSignUpBox.Visible = false;
            dvWelcomeBox.Visible = true;
            divLogin.Visible = false;
            lblWelcomeUser.Text = "Welcome " + objPage.GetState(CustomerSupport.CustomerSupportPage.UserName);
            lnkSignout.Visible = true;
            
            switch (SetTab)
            {
                case 1: strTab1="MenuTabActive"; break;
                case 2: strTab2 = "MenuTabActive"; break;
                case 3: strTab3 = "MenuTabActive"; break;
                case 4: strTab4 = "MenuTabActive"; break;
                case 5: strTab5 = "MenuTabActive"; break;
                case 6: strTab6 = "MenuTabActive"; break;
                default: break;
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
        Response.Redirect(CustomerSupport.Utility.SysResource.HomePath+"/"+GetState(CustomerSupport.CustomerSupportPage.Account_Name));
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
